﻿/*
 License: https://github.com/chengderen/Smartflow/blob/master/LICENSE 
 Home page: https://github.com/chengderen/Smartflow

 Note: to build on C# 3.0 + .NET 4.0
 Author:chengderen
 Email:237552006@qq.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Smartflow.Enums;
using System.Xml.Serialization;
using System.Data;

using Dapper;

namespace Smartflow.Elements
{
    [XmlInclude(typeof(Command))]
    [XmlInclude(typeof(List<Rule>))]
    [XmlInclude(typeof(List<Transition>))]
    public class Decision : Node
    {
        public override WorkflowNodeCategeory NodeType
        {
            get { return WorkflowNodeCategeory.Decision; }
        }

        [XmlElement("command")]
        public Command Command
        {
            get;
            set;
        }

        [XmlElement("rule")]
        public List<Rule> Rules
        {
            get;
            set;
        }
  

        internal override void Persistent()
        {
            base.Persistent();

            if (Command != null)
            {
                Command.INSTANCEID = INSTANCEID;
                Command.RNID = NID;
                Command.Persistent();
            }
            if (Rules != null)
            {
                foreach (Rule r in Rules)
                {
                    r.INSTANCEID = INSTANCEID;
                    r.RNID = NID;
                    r.Persistent();
                }
            }
        }
    }
}
