using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Client.Blazor.Components
{
    public partial class TreeView<TNode> : ComponentBase
    {
        [Parameter] 
        public IEnumerable<TNode> Nodes { get; set; }

        [Parameter] 
        public RenderFragment<TNode> TitleTemplate { get; set; }
        [Parameter] public TNode SelectedNode { get; set; }
        [Parameter] public EventCallback<TNode> SelectedNodeChanged { get; set; }
        [Parameter] public Func<TNode, IEnumerable<TNode>> ChildSelector { get; set; }
        [Parameter] public IList<TNode> ExpandedNodes { get; set; } = new List<TNode>();
        [Parameter] public EventCallback<IList<TNode>> ExpandedNodesChanged { get; set; }
        [Parameter] public Func<TNode, bool> HasChildNodes { get; set; } = node => true;
        [Parameter] public bool Visible { get; set; } = true;

        private void OnToggleNode(TNode node, bool expand)
        {
            bool expanded = ExpandedNodes.Contains(node);

            if (expanded && !expand)
            {
                ExpandedNodes.Remove(node);
                ExpandedNodesChanged.InvokeAsync(ExpandedNodes);
            }
            else if (!expanded && expand)
            {
                ExpandedNodes.Add(node);
                ExpandedNodesChanged.InvokeAsync(ExpandedNodes);
            }
        }

        private void OnSelectNode(TNode node)
        {
            SelectedNode = node;
            SelectedNodeChanged.InvokeAsync(node);
        }
    }
}
