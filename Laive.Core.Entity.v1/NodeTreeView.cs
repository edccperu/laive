using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Core.Entity
{
    /// <summary>
    /// Entidad para node de un treeview
    /// </summary>
    public class NodeTreeView
    {
        /// <summary>
        /// node id
        /// </summary>
        public string id { get; set; } 
        
        /// <summary>
        /// node text for display.
        /// </summary>
        public string text { get; set; }  

        /// <summary>
        /// node value
        /// </summary>
        public string value { get; set; }
 
        /// <summary>
        /// whether to show checkbox
        /// </summary>
        public bool showcheck { get; set; }

        /// <summary>
        /// Checkbox checking state. 0 for unchecked, 1 for partial checked, 2 for checked.
        /// </summary>
        public int checkstate { get; set; }

        /// <summary>
        /// If hasChildren and complete set to true, and ChildNodes is empty, tree will request server to get sub node.
        /// </summary>
        public bool hasChildren { get; set; }

        /// <summary>
        /// Expand or collapse.
        /// </summary>
        public bool isexpand { get; set; }

        /// <summary>
        /// See hasChildren.
        /// </summary>
        public bool complete { get; set; }

        /// <summary>
        /// child nodes
        /// </summary>
        public List<NodeTreeView> ChildNodes { get; set; }
    }
}
