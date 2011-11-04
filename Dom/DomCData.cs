﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jtc.CsQuery
{
    public interface IDomCData : IDomSpecialElement
    {

    }



    public class DomCData : DomObject<DomCData>, IDomCData
    {
        public DomCData()
            : base()
        {

        }
        public DomCData(CsQuery owner): base(owner)
        {
            
        }
        public override string NodeValue
        {
            get
            {
                return NonAttributeData;
            }
            set
            {
                NonAttributeData = value;
            }
        }
        public override NodeType NodeType
        {
            get { return NodeType.CDATA_SECTION_NODE; }
        }
        public override string Render()
        {
            return GetHtml(NonAttributeData);
        }
        protected string GetHtml(string innerText)
        {
            return "<![CDATA[" + innerText + ">";
        }
        public override string ToString()
        {
            string innerText = NonAttributeData.Length > 80 ? NonAttributeData.Substring(0, 80) + " ... " : NonAttributeData;
            return GetHtml(innerText);
        }
        #region IDomSpecialElement Members

        public string NonAttributeData
        {
            get;
            set;
        }
        public override bool InnerHtmlAllowed
        {
            get { return false; }
        }
        public override bool HasChildren
        {
            get { return false; }
        }
        public override bool Complete
        {
            get { return true; }
        }
        public string Text
        {
            get
            {
                return NonAttributeData;
            }
            set
            {
                NonAttributeData = value;
            }
        }
        public override DomCData Clone()
        {
            DomCData clone = base.Clone();
            clone.NonAttributeData =NonAttributeData;
            return clone;
        }

        #endregion
    }
    
}