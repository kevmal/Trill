﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.StreamProcessing
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    internal partial class GroupedWindowTemplate : CommonPipeTemplate
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            this.Write(@"// *********************************************************************
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License
// *********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

using Microsoft.StreamProcessing;
using Microsoft.StreamProcessing.Internal;
using Microsoft.StreamProcessing.Internal.Collections;
using Microsoft.StreamProcessing.Aggregates;

");


  List<string> genericParamList = new List<string>();
  int oldCount = 0;
  var TKey = keyType.GetCSharpSourceSyntax(ref genericParamList);
  var keyGenericParameters = new List<string>(genericParamList.Skip(oldCount));

  oldCount = genericParamList.Count;
  var TInput = inputType.GetCSharpSourceSyntax(ref genericParamList);
  var inputGenericParameters = new List<string>(genericParamList.Skip(oldCount));

  oldCount = genericParamList.Count;
  var TState = stateType.GetCSharpSourceSyntax(ref genericParamList);
  var stateGenericParameters = new List<string>(genericParamList.Skip(oldCount));

  oldCount = genericParamList.Count;
  var TOutput = outputType.GetCSharpSourceSyntax(ref genericParamList);
  var outputGenericParameters = new List<string>(genericParamList.Skip(oldCount));

  var genericParameters = genericParamList.BracketedCommaSeparatedString();
  var TKeyTInputGenericParameters = keyGenericParameters.Concat(inputGenericParameters).BracketedCommaSeparatedString();
  var TKeyTOutputGenericParameters = keyGenericParameters.Concat(outputGenericParameters).BracketedCommaSeparatedString();

  var BatchGeneratedFrom_TKey_TInput = Transformer.GetBatchClassName(keyType, inputType);

  var genericParameters2 = string.Format("<{0}, {1}>", TKey, TOutput);
  if (!keyType.KeyTypeNeedsGeneratedMemoryPool() && outputType.MemoryPoolHasGetMethodFor())
      genericParameters2 = string.Empty;
  else if (!outputType.CanRepresentAsColumnar())
      genericParameters2 = string.Empty;

  Func<string, string> assignToOutput = rhs =>
    this.outputType.IsAnonymousType()
    ?
    rhs
    :
    (
    this.outputFields.Count() == 1
    ?
    string.Format("this.batch.{0}.col[c] = {1};", this.outputFields.First().Name, rhs)
    :
    "temporaryOutput = " + rhs + ";\r\n" + String.Join("\r\n", this.outputFields.Select(f => "dest_" + f.Name + "[c] = temporaryOutput." + f.OriginalName + ";")))
    ;

  var getOutputBatch = string.Format("this.pool.Get(out genericOutputbatch); this.batch = ({0}{1})genericOutputbatch;",
          Transformer.GetBatchClassName(keyType, outputType),
          TKeyTOutputGenericParameters);


            this.Write("[assembly: IgnoresAccessChecksTo(\"Microsoft.StreamProcessing\")]\r\n\r\n// genericPara" +
                    "ms2 = \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(genericParameters2));
            this.Write("\"\r\n\r\n[DataContract]\r\nstruct StateAndActive\r\n{\r\n    [DataMember]\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(" state;\r\n    [DataMember]\r\n    public ulong active;\r\n}\r\n\r\n[DataContract]\r\nstruct " +
                    "HeldStateStruct\r\n{\r\n    [DataMember]\r\n    public long timestamp;\r\n    [DataMembe" +
                    "r]\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(" state;\r\n}\r\n\r\n[DataContract]\r\nsealed class HeldState\r\n{\r\n    [DataMember]\r\n    pu" +
                    "blic long timestamp;\r\n    [DataMember]\r\n    public StateAndActive state;\r\n}\r\n\r\n/" +
                    "/ TKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("\r\n// TInput: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write("\r\n// TState: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("\r\n// TOutput: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOutput));
            this.Write("\r\n// *********************************************************************\r\n// Co" +
                    "pyright (c) Microsoft Corporation.  All rights reserved.\r\n// Licensed under the " +
                    "MIT License\r\n// ****************************************************************" +
                    "*****\r\n");

  var resultMessageMemoryPoolGenericParameters = $"<{TKey}, {TResult}>";
  if (resultType == typeof(int) || resultType == typeof(long) || resultType == typeof(string)) resultMessageMemoryPoolGenericParameters = string.Empty;

  getOutputBatch = $"this.pool.Get(out genericOutputbatch); this.batch = ({Transformer.GetBatchClassName(typeof(Empty), resultType)}{UnitTResultGenericParameters})genericOutputbatch;";


            this.Write("\r\n// TKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("\r\n// TInput: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write("\r\n// TState: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("\r\n// TOutput: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOutput));
            this.Write("\r\n// TResult: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write("\r\n\r\n/// <summary>\r\n/// Operator has has no support for ECQ\r\n/// </summary>\r\n[Data" +
                    "Contract]\r\ninternal sealed class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write(this.ToStringHelper.ToStringWithCulture(genericParameters));
            this.Write(" : UnaryPipe<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write(">\r\n{\r\n    private readonly Func<PlanNode, IQueryObject, PlanNode> queryPlanGenera" +
                    "tor;\r\n    private readonly MemoryPool<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write("> pool;\r\n\r\n    ");
 if (this.useCompiledInitialState) { 
            this.Write("    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("> initialState;\r\n    ");
 } 
            this.Write("\r\n    ");
 if (this.useCompiledAccumulate) { 
            this.Write("    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", long, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("> accumulate;\r\n    ");
 } 
            this.Write("\r\n    ");
 if (this.useCompiledDeaccumulate) { 
            this.Write("    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", long, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("> deaccumulate;\r\n    ");
 } 
            this.Write("\r\n    ");
 if (this.useCompiledDifference) { 
            this.Write("    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write("> difference;\r\n    ");
 } 
            this.Write("\r\n    ");
 if (this.useCompiledComputeResult) { 
            this.Write("    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOutput));
            this.Write("> computeResult;\r\n    ");
 } 
            this.Write("\r\n    private readonly IEqualityComparerExpression<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("> keyComparer;\r\n    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("> keySelector;\r\n\r\n    ");
 if (!this.isUngrouped) { 
            this.Write("    [DataMember]\r\n    private FastDictionary3<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", HeldState> heldAggregates;\r\n    ");
 } else { 
            this.Write("\r\n    private HeldState currentState;\r\n    [DataMember]\r\n    private bool isDirty" +
                    ";\r\n    ");
 } 
            this.Write("\r\n    private StreamMessage<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write("> genericOutputbatch;\r\n    [DataMember]\r\n    private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Transformer.GetBatchClassName(typeof(Empty), resultType)));
            this.Write(this.ToStringHelper.ToStringWithCulture(UnitTResultGenericParameters));
            this.Write(" batch;\r\n\r\n    [DataMember]\r\n    private long lastSyncTime = long.MinValue;\r\n\r\n  " +
                    "  private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(" currentKey;\r\n\r\n    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(staticCtor));
            this.Write("\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("() { }\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("(\r\n        IStreamable<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write("> stream,\r\n        IStreamObserver<Microsoft.StreamProcessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write("> observer,\r\n        IAggregate<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TState));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOutput));
            this.Write("> aggregate,\r\n        Func<PlanNode, IQueryObject, PlanNode> queryPlanGenerator)\r" +
                    "\n        : base(stream, observer)\r\n    {\r\n        this.queryPlanGenerator = quer" +
                    "yPlanGenerator;\r\n\r\n        ");
 if (this.useCompiledInitialState) { 
            this.Write("        initialState = aggregate.InitialState().Compile();\r\n        ");
 } 
            this.Write("        ");
 if (this.useCompiledAccumulate) { 
            this.Write("        accumulate = aggregate.Accumulate().Compile();\r\n        ");
 } 
            this.Write("        ");
 if (this.useCompiledDeaccumulate) { 
            this.Write("        deaccumulate = aggregate.Deaccumulate().Compile();\r\n        ");
 } 
            this.Write("        ");
 if (this.useCompiledDifference) { 
            this.Write("        difference = aggregate.Difference().Compile();\r\n        ");
 } 
            this.Write("        ");
 if (this.useCompiledComputeResult) { 
            this.Write("        computeResult = aggregate.ComputeResult().Compile();\r\n        ");
 } 
            this.Write("\r\n        this.keyComparer = EqualityComparerExpression<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(">.Default;\r\n\r\n        this.pool = MemoryManager.GetMemoryPool<Microsoft.StreamPro" +
                    "cessing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write(">(); // as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Transformer.GetMemoryPoolClassName(typeof(Empty), this.resultType)));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultMessageMemoryPoolGenericParameters));
            this.Write(";\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n        this.batch.Allocate();\r\n\r\n        ");
 if (!this.isUngrouped) { 
            this.Write("        var generator = keyComparer.CreateFastDictionary3Generator<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", HeldState>(1, keyComparer.GetEqualsExpr().Compile(), keyComparer.GetGetHashCode" +
                    "Expr().Compile(), stream.Properties.QueryContainer);\r\n        heldAggregates = g" +
                    "enerator.Invoke();\r\n        ");
 } else { 
            this.Write("        isDirty = false;\r\n        ");
 } 
            this.Write(@"    }

    public override void ProduceQueryPlan(PlanNode previous)
    {
        Observer.ProduceQueryPlan(queryPlanGenerator(previous, this));
    }

    protected override void FlushContents()
    {
        if (this.batch == null || this.batch.Count == 0) return;
        this.Observer.OnNext(this.batch);
        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n        this.batch.Allocate();\r\n    }\r\n\r\n    protected override void DisposeSta" +
                    "te() => this.batch.Free();\r\n\r\n    public override int CurrentlyBufferedOutputCou" +
                    "nt => this.batch.Count;\r\n\r\n    public override int CurrentlyBufferedInputCount =" +
                    "> ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.isUngrouped ? "0" : "heldAggregates.Count"));
            this.Write(";\r\n\r\n    public override unsafe void OnNext(StreamMessage<Microsoft.StreamProcess" +
                    "ing.Empty, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInput));
            this.Write("> inputBatch)\r\n    {\r\n        ");
 if (!this.isUngrouped) { 
            this.Write("        HeldState currentState = null;\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(" currentKey = default;\r\n        int currentHash = 0;\r\n        ");
 } 
            this.Write("\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BatchGeneratedFrom_Unit_TInput));
            this.Write(this.ToStringHelper.ToStringWithCulture(UnitTInputGenericParameters));
            this.Write(" batch = inputBatch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BatchGeneratedFrom_Unit_TInput));
            this.Write(this.ToStringHelper.ToStringWithCulture(UnitTInputGenericParameters));
            this.Write(";\r\n\r\n        ");
 if (this.outputFields.Count() > 1) { 
            this.Write("        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write(" temporaryOutput;\r\n        ");
 } 
            this.Write("\r\n        // Create locals that point directly to the arrays within the columns i" +
                    "n the input batch.\r\n");
 foreach (var f in this.inputFields) { 
            this.Write("\r\n");
 if (f.canBeFixed) { 
            this.Write("\r\n        fixed (");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.TypeName));
            this.Write("* ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = batch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col)\r\n        {\r\n");
 } else { 
            this.Write("\r\n        var ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = batch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col;\r\n\r\n");
 } 
 } 
            this.Write("\r\n        // Create locals that point directly to the arrays within the columns i" +
                    "n the output batch.\r\n");
 foreach (var f in this.outputFields) { 
            this.Write("\r\n");
 if (f.canBeFixed) { 
            this.Write("\r\n        fixed (");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.TypeName));
            this.Write("* dest_");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(" = this.batch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col)\r\n        {\r\n");
 } else { 
            this.Write("\r\n        var dest_");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(" = this.batch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col;\r\n\r\n");
 } 
 } 
            this.Write(@"
        fixed (long* col_vsync = batch.vsync.col)
        fixed (long* col_vother = batch.vother.col)
        fixed (long* col_bv = batch.bitvector.col)
        {
            for (int i = 0; i < batch.Count; i++)
            {
                if ((col_bv[i >> 6] & (1L << (i & 0x3f))) != 0)
                {
                    if (col_vother[i] == long.MinValue)
                    {
                        // We have found a row that corresponds to punctuation
                        OnPunctuation(col_vsync[i]);

                        int c = this.batch.Count;
                        this.batch.vsync.col[c] = col_vsync[i];
                        this.batch.vother.col[c] = long.MinValue;
                        this.batch.key.col[c] = default;
                        this.batch[c] = default;
                        this.batch.hash.col[c] = 0;
                        this.batch.bitvector.col[c >> 6] |= (1L << (c & 0x3f));
                        this.batch.Count++;
                        if (this.batch.Count == Config.DataBatchSize) FlushContents();
                    }
                    continue;
                }

                var col_key_i = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(keySelector));
            this.Write(";\r\n                var col_hash_i = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(keyComparerGetHashCode("col_key_i")));
            this.Write(";\r\n\r\n                var syncTime = col_vsync[i];\r\n\r\n                // Handle ti" +
                    "me moving forward\r\n                if (syncTime > this.lastSyncTime)\r\n          " +
                    "      {\r\n                    ");
 if (this.isUngrouped) { 
            this.Write(@"                    if ((currentState != null) && isDirty)   // there exists earlier state
                    {
                        int _c = this.batch.Count;
                        this.batch.vsync.col[_c] = currentState.timestamp;
                        this.batch.vother.col[_c] = StreamEvent.InfinitySyncTime;
                        {
                            var currentStateStateState = currentState.state.state;
                            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("currentKey", computeResult("currentStateStateState"))));
            this.Write(@"
                        }
                        this.batch.hash.col[_c] = 0;
                        this.batch.Count++;
                        if (this.batch.Count == Config.DataBatchSize)
                        {
                            this.batch.Seal();
                            this.Observer.OnNext(this.batch);
                            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n                            this.batch.Allocate();\r\n                        }\r\n" +
                    "                    }\r\n                    isDirty = false;\r\n                   " +
                    " ");
 } else { 
            this.Write("                    int iter1 = FastDictionary3<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(@", HeldState>.IteratorStart;
                    while (this.heldAggregates.IterateDirty(ref iter1))
                    {
                        var iter1entry = this.heldAggregates.entries[iter1];

                            int _c = this.batch.Count;
                            this.batch.vsync.col[_c] = iter1entry.value.timestamp;
                            this.batch.vother.col[_c] = StreamEvent.InfinitySyncTime;
                            {
                                var iter1entryValueStateState = iter1entry.value.state.state;
                                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("iter1entry.key", computeResult("iter1entryValueStateState"))));
            this.Write(@"
                            }
                            this.batch.hash.col[_c] = iter1entry.hash;
                            this.batch.Count++;
                            if (this.batch.Count == Config.DataBatchSize)
                            {
                                this.batch.Seal();
                                this.Observer.OnNext(this.batch);
                                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write(@"
                                this.batch.Allocate();
                        }
                    }

                    // Time has moved forward, clean the held aggregates
                    this.heldAggregates.Clean();

                    // reset currentState so that we can later force a re-get and set it dirty
                    currentState = null;
                    ");
 } 
            this.Write("\r\n                    // Since sync time changed, set lastSyncTime\r\n             " +
                    "       this.lastSyncTime = syncTime;\r\n                }\r\n\r\n                ");
 if (this.isUngrouped) { 
            this.Write("                if (currentState == null)\r\n                {\r\n                   " +
                    " currentState = new HeldState();\r\n                    currentState.state.state =" +
                    " ");
            this.Write(this.ToStringHelper.ToStringWithCulture(initialState));
            this.Write(@";
                    currentState.state.active = 1; // start edge only
                    currentState.timestamp = syncTime;
                    isDirty = true;
                }
                else
                {
                    if (!isDirty)
                    {
                        // Output end edge
                        int _c = this.batch.Count;
                        this.batch.vsync.col[_c] = syncTime;
                        this.batch.vother.col[_c] = currentState.timestamp;
                        {
                            var currentStateStateState = currentState.state.state;
                            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("currentKey", computeResult("currentStateStateState"))));
            this.Write(@"
                        }
                        this.batch.hash.col[_c] = 0;
                        this.batch.Count++;
                        if (this.batch.Count == Config.DataBatchSize)
                        {
                            this.batch.Seal();
                            this.Observer.OnNext(this.batch);
                            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n                            this.batch.Allocate();\r\n                        }\r\n" +
                    "                        currentState.timestamp = syncTime;\r\n                    " +
                    "    isDirty = true;\r\n                    }\r\n                }\r\n                ");
 } else { 
            this.Write("\r\n                if (currentState == null || ((!");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.isUngrouped ? "true" : "false"));
            this.Write(") && (currentHash != col_hash_i || !(");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.keyComparerEquals("currentKey", "col_key_i")));
            this.Write(@"))))
                {
                    // Need to retrieve the key from the dictionary
                    currentKey = col_key_i;
                    currentHash = col_hash_i;

                    int index;

                    bool heldAggregatesLookup = false;
                    {
                        int num = currentHash & 0x7fffffff;
                        index = num % this.heldAggregates.Size;

                        do
                        {
                            if ((this.heldAggregates.bitvector[index >> 3] & (0x1 << (index & 0x7))) == 0)
                            {
                                heldAggregatesLookup = false;
                                break;
                            }

                            if ((currentHash == this.heldAggregates.entries[index].hash) && (");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.keyComparerEquals("currentKey", "this.heldAggregates.entries[index].key")));
            this.Write(@"))
                            {
                                heldAggregatesLookup = true;
                                break;
                            }

                            index++;
                            if (index == this.heldAggregates.Size)
                                index = 0;
                        } while (true);
                    }

                    if (!heldAggregatesLookup)
                    {
                        // New group. Create new state
                        currentState = new HeldState();
                        currentState.state.state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(initialState));
            this.Write(@";
                        currentState.state.active = 1; // start edge only
                        currentState.timestamp = syncTime;

                        // No output because initial state is empty
                        this.heldAggregates.Insert(ref index, currentKey, currentState, currentHash);
                    }
                    else
                    {
                        // read new currentState from _heldAgg index
                        currentState = this.heldAggregates.entries[index].value;

                        if (this.heldAggregates.IsClean(ref index))
                        {
                            // Output end edge
                            int _c = this.batch.Count;
                            this.batch.vsync.col[_c] = syncTime;
                            this.batch.vother.col[_c] = currentState.timestamp;
                            {
                                var currentStateStateState = currentState.state.state;
                                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("currentKey", computeResult("currentStateStateState"))));
            this.Write(@"
                            }
                            this.batch.hash.col[_c] = currentHash;
                            this.batch.Count++;
                            if (this.batch.Count == Config.DataBatchSize)
                            {
                                this.batch.Seal();
                                this.Observer.OnNext(this.batch);
                                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write(@"
                                this.batch.Allocate();
                            }
                            currentState.timestamp = syncTime;
                            this.heldAggregates.SetDirty(ref index);
                        }
                    }
                }
                ");
 } 
            this.Write("\r\n                currentState.state.state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(accumulate("currentState.state.state", "col_vsync[i]" /*, "col_payload[i]"*/)));
            this.Write(";\r\n            }\r\n        }\r\n\r\n        ");
 foreach (var f in this.inputFields.Where(fld => fld.canBeFixed)) { 
            this.Write("\r\n        }\r\n        ");
 } 
            this.Write("        ");
 foreach (var f in this.outputFields.Where(fld => fld.canBeFixed)) { 
            this.Write("\r\n        }\r\n        ");
 } 
            this.Write("\r\n        batch.Release();\r\n        batch.Return();\r\n    }\r\n\r\n    public void OnP" +
                    "unctuation(long syncTime)\r\n    {\r\n\r\n        ");
 if (this.outputFields.Count() > 1) { 
            this.Write("        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TResult));
            this.Write(" temporaryOutput;\r\n        ");
 foreach (var f in this.outputFields) { 
            this.Write("\r\n        var dest_");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(" = this.batch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col;\r\n        ");
 } 
            this.Write("        ");
 } 
            this.Write("\r\n        // Handle time moving forward\r\n        if (syncTime > this.lastSyncTime" +
                    ")\r\n        {\r\n            ");
 if (this.isUngrouped) { 
            this.Write(@"            if ((currentState != null) && isDirty) // need to send start edge if state is dirty
            {
                int _c = this.batch.Count;
                this.batch.vsync.col[_c] = currentState.timestamp;
                this.batch.vother.col[_c] = StreamEvent.InfinitySyncTime;
                {
                    var currentStateStateState = currentState.state.state;
                    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("currentKey", computeResult("currentStateStateState"))));
            this.Write(@"
                }
                this.batch.hash.col[_c] = 0;
                this.batch.Count++;
                if (this.batch.Count == Config.DataBatchSize)
                {
                    this.batch.Seal();
                    this.Observer.OnNext(this.batch);
                    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n                    this.batch.Allocate();\r\n                }\r\n            }\r\n " +
                    "           isDirty = false;\r\n            ");
 } else { 
            this.Write("            int iter1 = FastDictionary3<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(@", HeldState>.IteratorStart;
            while (this.heldAggregates.IterateDirty(ref iter1))
            {
                var iter1entry = this.heldAggregates.entries[iter1];

                int _c = this.batch.Count;
                this.batch.vsync.col[_c] = iter1entry.value.timestamp;
                this.batch.vother.col[_c] = StreamEvent.InfinitySyncTime;
                {
                    var iter1entryValueStateState = iter1entry.value.state.state;
                    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(finalResultSelector("iter1entry.key", computeResult("iter1entryValueStateState"))));
            this.Write(@"
                }
                this.batch.hash.col[_c] = iter1entry.hash;
                this.batch.Count++;
                if (this.batch.Count == Config.DataBatchSize)
                {
                    this.batch.Seal();
                    this.Observer.OnNext(this.batch);
                    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n                    this.batch.Allocate();\r\n                }\r\n            }\r\n\r" +
                    "\n            // Time has moved forward, clean the held aggregates\r\n            t" +
                    "his.heldAggregates.Clean();\r\n            ");
 } 
            this.Write("\r\n            // Since sync time changed, set lastSyncTime\r\n            this.last" +
                    "SyncTime = syncTime;\r\n        }\r\n        if (this.batch.Count > 0)\r\n        {\r\n " +
                    "           this.batch.Seal();\r\n            this.Observer.OnNext(this.batch);\r\n  " +
                    "          ");
            this.Write(this.ToStringHelper.ToStringWithCulture(getOutputBatch));
            this.Write("\r\n            this.batch.Allocate();\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
}
