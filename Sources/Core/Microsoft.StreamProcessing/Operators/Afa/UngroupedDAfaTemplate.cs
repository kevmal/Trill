﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.StreamProcessing
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class UngroupedDAfaTemplate : AfaTemplate
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"// *********************************************************************
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License
// *********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.StreamProcessing;
using Microsoft.StreamProcessing.Internal;
using Microsoft.StreamProcessing.Internal.Collections;

// CompiledUngroupedDAfaPipe
// TPayload: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write("\r\n// TRegister: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("\r\n// TAccumulator: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TAccumulator));
            this.Write("\r\n\r\n    [DataContract]\r\n    public sealed class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write(" : CompiledAfaPipeBase<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TAccumulator));
            this.Write(">\r\n    {\r\n        [DataMember]\r\n        private int activeState_state;\r\n        [" +
                    "DataMember]\r\n        private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(@" activeState_register;
        [DataMember]
        private long activeState_PatternStartTimestamp;

        [DataMember]
        private byte seenEvent;
        [DataMember]
        private FastLinkedList<OutputEvent<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">> tentativeOutput;\r\n        [DataMember]\r\n        private long lastSyncTime;\r\n\r\n" +
                    "        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(staticCtor));
            this.Write("\r\n\r\n        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("(\r\n            IStreamable<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("> stream,\r\n            IStreamObserver<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("> observer,\r\n            object afa,\r\n            long MaxDuration)\r\n            " +
                    ": base(stream, observer, afa, MaxDuration)\r\n        {\r\n            activeState_s" +
                    "tate = -1;\r\n\r\n            ");
 if (!this.isSyncTimeSimultaneityFree) { 
            this.Write("                seenEvent = 0;\r\n                tentativeOutput = new FastLinkedL" +
                    "ist<OutputEvent<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>();\r\n                lastSyncTime = -1;\r\n            ");
 } 
            this.Write("        }\r\n\r\n        public override int CurrentlyBufferedInputCount => 0;\r\n\r\n   " +
                    "     public override unsafe void OnNext(StreamMessage<Microsoft.StreamProcessing" +
                    ".Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write("> batch)\r\n        {\r\n            Stack<int> stack = new Stack<int>();\r\n          " +
                    "  var tentativeFindTraverser = new FastLinkedList<OutputEvent<Microsoft.StreamPr" +
                    "ocessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>.ListTraverser(tentativeOutput);\r\n            var tentativeOutputIndex = 0;\r\n\r\n" +
                    "            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchTypeName));
            this.Write(" sourceBatch = batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchTypeName));
            this.Write(";\r\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchTypeName));
            this.Write(" resultBatch = this.batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchTypeName));
            this.Write(@";

            var count = batch.Count;

            var dest_vsync = this.batch.vsync.col;
            var dest_vother = this.batch.vother.col;
            var destkey = this.batch.key.col;
            var dest_hash = this.batch.hash.col;

            var srckey = batch.key.col;

            ");
 foreach (var f in this.sourceFields) { 
            this.Write("\r\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BeginColumnPointerDeclaration(f, "sourceBatch")));
            this.Write("\r\n            ");
 } 
            this.Write("            ");
 foreach (var f in this.resultFields) { 
            this.Write("\r\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BeginColumnPointerDeclaration(f, "resultBatch")));
            this.Write("\r\n            ");
 } 
            this.Write(@"
            fixed (long* src_bv = batch.bitvector.col, src_vsync = batch.vsync.col, src_vother = batch.vother.col)
            {
                fixed (int* src_hash = batch.hash.col)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if ((src_bv[i >> 6] & (1L << (i & 0x3f))) == 0)
                        {
                            long synctime = src_vsync[i];

                            ");
 if (!this.isSyncTimeSimultaneityFree) { 
            this.Write(@"                            {
                                int index, hash;

                                if (synctime > lastSyncTime) // move time forward
                                {
                                    seenEvent = 0;

                                    if (this.tentativeOutput.Count > 0)
                                    {
                                        tentativeOutputIndex = 0;

                                        while (this.tentativeOutput.Iterate(ref tentativeOutputIndex))
                                        {
                                            var elem = this.tentativeOutput.Values[tentativeOutputIndex];

                                            dest_vsync[iter] = lastSyncTime;
                                            dest_vother[iter] = elem.other;
                                            this.batch[iter] = elem.payload;
                                            dest_hash[iter] = 0;
                                            iter++;

                                            if (iter == Config.DataBatchSize)
                                            {
                                                FlushContents();
                                                resultBatch = this.batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchTypeName));
            this.Write(";\r\n                                                dest_vsync = this.batch.vsync." +
                    "col;\r\n                                                dest_vother = this.batch.v" +
                    "other.col;\r\n                                                destkey = this.batch" +
                    ".key.col;\r\n                                                dest_hash = this.batc" +
                    "h.hash.col;\r\n                                            }\r\n                    " +
                    "                    }\r\n                                        tentativeOutput.C" +
                    "lear(); // Clear the tentative output list\r\n                                    " +
                    "}\r\n                                    lastSyncTime = synctime;\r\n               " +
                    "                 }\r\n\r\n                                if (seenEvent > 0) // Inco" +
                    "ming event is a simultaneous one\r\n                                {\r\n           " +
                    "                         if (seenEvent == 1) // Detecting first duplicate, need " +
                    "to adjust state\r\n                                    {\r\n                        " +
                    "                seenEvent = 2;\r\n\r\n                                        // Del" +
                    "ete tentative output for that key\r\n                                        tenta" +
                    "tiveOutput.Clear();\r\n\r\n                                        // Delete active " +
                    "states for that key\r\n                                        activeState_state =" +
                    " -1;\r\n                                    }\r\n\r\n                                 " +
                    "   // Dont process this event\r\n                                    continue;\r\n  " +
                    "                              }\r\n                                else\r\n         " +
                    "                       {\r\n                                    seenEvent = 1;\r\n  " +
                    "                              }\r\n                            }\r\n                " +
                    "            ");
 } 
            this.Write(@"
                            /* (1) Process currently active states */

                            if (activeState_state >= 0)
                            {
                                //while (activeFindTraverser.Next(out index))
                                {
                                    if (activeState_PatternStartTimestamp + MaxDuration > synctime)
                                    {
                                        switch (activeState_state) {
                                            ");
 foreach (var sourceNodeInfo in this.currentlyActiveInfo) { 
            this.Write("\r\n                                            case ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceNodeInfo.Item1));
            this.Write(" :\r\n                                                activeState_state = -1; // as" +
                    "sume the arc does not fire\r\n                                                ");
 foreach (var edge in sourceNodeInfo.Item2) { 
            this.Write("\r\n                                                if (");
            this.Write(this.ToStringHelper.ToStringWithCulture(edge.Fence("synctime", "batch[i]", "activeState_register")));
            this.Write(") {\r\n                                                    // assign new register v" +
                    "alue\r\n                                                    ");
 UpdateRegisterValue(edge, "activeState_register", "synctime", "batch[i]", "activeState_register"); 
            this.Write("                                                    activeState_register = newReg" +
                    ";\r\n                                                    // target nodes\r\n        " +
                    "                                            ");
 foreach (var ns in edge.EpsilonReachableNodes) { 
            this.Write("\r\n                                                    // target state: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(" (");
            this.Write(this.ToStringHelper.ToStringWithCulture(isFinal[ns] ? "final" : "not final"));
            this.Write(")\r\n                                                    activeState_state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(";\r\n                                                    ");
 IfFinalStateProduceOutput(52, ns, string.Empty, "synctime", "activeState_PatternStartTimestamp", "srckey[i]", "src_hash[i]"); 
            this.Write("                                                    ");
 if (hasOutgoingArcs[ns]) { 
            this.Write("\r\n                                                    // target node has outgoing" +
                    " edges\r\n                                                    activeState_PatternS" +
                    "tartTimestamp = synctime;\r\n                                                    ");
 } else { 
            this.Write("\r\n                                                    // target node does not hav" +
                    "e any outgoing edges\r\n                                                    active" +
                    "State_state = -1;\r\n                                                    ");
 } 
            this.Write("                                                    ");
 } 
            this.Write("\r\n                                                    break; // DFA, so only one " +
                    "arc fires\r\n                                                }\r\n                  " +
                    "                              ");
 } 
            this.Write("\r\n                                                break; // Break out of switch c" +
                    "ase\r\n\r\n                                            ");
 } 
            this.Write(@"                                        }

                                    }
                                }
                            }

                            /* (2) Start new activations from the start state(s) */
                            if (activeState_state >= 0) continue;

                            ");
 foreach (var sourceNodeInfo in this.newActivationInfo) { 
            this.Write("\r\n                                // start node: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceNodeInfo.Item1));
            this.Write("\r\n                                ");
 foreach (var edge in sourceNodeInfo.Item2) { 
            this.Write("\r\n                                if (");
            this.Write(this.ToStringHelper.ToStringWithCulture(edge.Fence("synctime", "batch[i]", "defaultRegister")));
            this.Write(") {\r\n                                    // initialize register\r\n                " +
                    "                    ");
 UpdateRegisterValue(edge, "defaultRegister", "synctime", "batch[i]", "defaultRegister"); 
            this.Write("                                    activeState_register = newReg;\r\n\r\n           " +
                    "                         // target nodes\r\n                                    ");
 foreach (var ns in edge.EpsilonReachableNodes) { 
            this.Write("\r\n                                    // target state: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(" (");
            this.Write(this.ToStringHelper.ToStringWithCulture(isFinal[ns] ? "final" : "not final"));
            this.Write(")\r\n                                    activeState_state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(";\r\n                                    ");
 IfFinalStateProduceOutput(52, ns, string.Empty, "synctime", "synctime", "srckey[i]", "src_hash[i]"); 
            this.Write("                                    ");
 if (hasOutgoingArcs[ns]) { 
            this.Write(@"
                                    // target node has outgoing edges
                                    {
                                        activeState_PatternStartTimestamp = synctime;
                                    }
                                    ");
 } else { 
            this.Write("\r\n                                    // target node does not have any outgoing e" +
                    "dges\r\n                                    activeState_state = -1;\r\n             " +
                    "                       ");
 } 
            this.Write("                                    ");
 } 
            this.Write("\r\n                                }\r\n                                ");
 } 
            this.Write("                            ");
 } 
            this.Write("\r\n                        }\r\n                        else if (src_vother[i] < 0 )" +
                    "\r\n                        {\r\n                            long synctime = src_vsy" +
                    "nc[i];\r\n");
  if (!this.isSyncTimeSimultaneityFree)
    { 
            this.Write(@"                            if (synctime > lastSyncTime) // move time forward
                            {
                                int index, hash;
                                seenEvent = 0;

                                if (this.tentativeOutput.Count > 0)
                                {
                                    tentativeOutputIndex = 0;

                                    while (this.tentativeOutput.Iterate(ref tentativeOutputIndex))
                                    {
                                        var elem = this.tentativeOutput.Values[tentativeOutputIndex];

                                        this.batch.vsync.col[iter] = lastSyncTime;
                                        this.batch.vother.col[iter] = elem.other;
                                        this.batch[iter] = elem.payload;
                                        this.batch.hash.col[iter] = 0;
                                        iter++;

                                        if (iter == Config.DataBatchSize)
                                        {
                                            FlushContents();
                                            resultBatch = this.batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchTypeName));
            this.Write(@";
                                        }
                                    }
                                    tentativeOutput.Clear(); // Clear the tentative output list
                                }
                                lastSyncTime = synctime;
                            }
");
  } 
            this.Write("                            OnPunctuation(synctime);\r\n                        }\r\n" +
                    "                    }\r\n                }\r\n            }\r\n            ");
 foreach (var f in this.sourceFields) { 
            this.Write("\r\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EndColumnPointerDeclaration(f)));
            this.Write("\r\n            ");
 } 
            this.Write("            ");
 foreach (var f in this.resultFields) { 
            this.Write("\r\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EndColumnPointerDeclaration(f)));
            this.Write("\r\n            ");
 } 
            this.Write("\r\n            batch.Free();\r\n        }\r\n    }\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
}
