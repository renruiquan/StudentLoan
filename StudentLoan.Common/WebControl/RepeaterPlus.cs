using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace StudentLoan.Common.WebControl
{
    /// <summary>
    /// 重写Repeater控件
    /// </summary>
    public class RepeaterPlus : System.Web.UI.WebControls.Repeater
    {
        private ITemplate emptyDataTemplate;

        [PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(TemplateControl))]
        public ITemplate EmptyDataTemplate
        {
            get { return emptyDataTemplate; }
            set { emptyDataTemplate = value; }
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (emptyDataTemplate != null)
            {
                if (this.Items.Count == 0)
                {
                    EmptyDataTemplate.InstantiateIn(this);

                }
            }
        }
    }
}