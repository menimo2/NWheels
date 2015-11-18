﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using NWheels.Extensions;
using NWheels.UI.Core;
using NWheels.UI.Uidl;
using NWheels.Processing;

namespace NWheels.UI.Toolbox
{
    [DataContract(Namespace = UidlDocument.DataContractNamespace)]
    public class Report<TContext, TCriteria, TScript, TResultRow> :
        WidgetBase<Report<TContext, TCriteria, TScript, TResultRow>, Empty.Data, Report<TContext, TCriteria, TScript, TResultRow>.IReportState>
        where TScript : ITransactionScript<TContext, TCriteria, IQueryable<TResultRow>>
        where TContext : class
        where TCriteria : class
    {
        public Report(string idName, ControlledUidlNode parent)
            : base(idName, parent)
        {
            base.WidgetType = "Report";
            base.TemplateName = "Report";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        [DataMember]
        public Form<TCriteria> CriteriaForm { get; set; }
        [DataMember]
        public DataGrid<TResultRow> ResultTable { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public UidlCommand ShowReport { get; set; }
        public UidlNotification<TContext> ContextSetter { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void DescribePresenter(PresenterBuilder<Report<TContext, TCriteria, TScript, TResultRow>, Empty.Data, IReportState> presenter)
        {
            CriteriaForm.UsePascalCase = true;
            CriteriaForm.Commands.Add(ShowReport);

            var attribute = typeof(TScript).GetCustomAttribute<TransactionScriptAttribute>();

            if ( attribute != null && attribute.SupportsInitializeInput )
            {
                presenter.On(ContextSetter)
                    .InvokeTransactionScript<TScript>()
                    .WaitForReply((script, data, state, context) => script.InitializeInput(context))
                    .Then(b => b.AlterModel(alt => alt.Copy(m => m.Input).To(m => m.State.Criteria))
                    .Then(bb => bb.Broadcast(CriteriaForm.ModelSetter).WithPayload(m => m.Input).TunnelDown()));
            }

            presenter.On(ShowReport)
                .InvokeTransactionScript<TScript>()
                .WaitForReply((script, data, state, input) => script.Execute(state.Criteria))
                .Then(b => b.Broadcast(ResultTable.DataReceived).WithPayload(m => m.Input).TunnelDown());
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        #region Overrides of WidgetUidlNode

        public override IEnumerable<WidgetUidlNode> GetNestedWidgets()
        {
            return base.GetNestedWidgets().Concat(new WidgetUidlNode[] { CriteriaForm, ResultTable });
        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        [ViewModelContract]
        public interface IReportState
        {
            TCriteria Criteria { get; set; }
        }
    }
}
