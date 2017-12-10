using System.Collections.Generic;

namespace AdventOfCode2017.Models
{
    /// <summary>
    /// Day 7 Node
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has child.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has child; otherwise, <c>false</c>.
        /// </value>
        public bool HasChild { get; set; }

        /// <summary>
        /// Gets or sets the child names.
        /// </summary>
        /// <value>
        /// The child names.
        /// </value>
        public List<string> ChildNames { get; set; }

        /// <summary>
        /// Gets or sets the child nodes.
        /// </summary>
        /// <value>
        /// The child nodes.
        /// </value>
        public List<Node> ChildNodes { get; set; }

        /// <summary>
        /// Gets or sets the total child weight.
        /// </summary>
        /// <value>
        /// The total child weight.
        /// </value>
        public int TotalChildWeight { get; set; }
    }
}
