using System.Collections.Generic;

namespace SetTheoryAPI.Models
{
    public class SetContainer
    {
        private List<int> _SetA = new List<int>();
        private List<int> _SetB = new List<int>();
        private List<int> _Universe = new List<int>();
        private int _Member;
        /// <summary>
        /// Defines Set A in a list of integers.
        /// </summary>
        public List<int> SetA { get => _SetA; set => _SetA = value; }
        /// <summary>
        /// Defines Set B in a list of integers.
        /// </summary>
        public List<int> SetB { get => _SetB; set => _SetB = value; }
        /// <summary>
        /// Defines a Universe in case of needing to handle complement.
        /// </summary>
        public List<int> Universe { get => _SetB; set => _SetB = value; }
        /// <summary>
        /// Defines an integer that's used to check for membership.
        /// </summary>
        public int Member { get => _Member; set => _Member = value; }
    }
}