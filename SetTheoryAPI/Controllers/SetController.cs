using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SetTheoryAPI.Models;

namespace SetTheoryAPI.Controllers
{
    public class SetController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return new string[] {"This", "is", "not working.."};
        }

        /// <summary>
        /// Checks the given set and member if the set contains the member.
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        [Route("api/set/Membership")]
        [HttpGet]
        public string Membership([FromBody] SetContainer set)
        {
            if (set.SetA.Contains(set.Member))
            {
                return $"SetA contains {set.Member}.";
            }
            else
            {
                return $"SetA doesn't contain {set.Member}";
            }

        }

        /// <summary>
        /// Performs an intersection on two given sets.
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        [Route("api/set/Intersection")]
        [HttpGet]
        public List<int> Intersection([FromBody] SetContainer set)
        {
            List<int> SetC = new List<int>();

            foreach (int aMember in set.SetA)
            {
                if (set.SetB.Contains(aMember))
                {
                    SetC.Add(aMember);
                }
            }

            return SetC;

        }
        /// <summary>
        /// Performs union on 2 given sets.
        /// </summary>
        /// <param name="set"></param>
        /// <returns>Unionized set</returns>
        [Route("api/set/Union")]
        [HttpGet]
        public List<int> Union([FromBody] SetContainer set)
        {
            List<int> SetC = set.SetB;

            foreach (int member in set.SetA)
            {
                SetC.Add(member);
            }

            return SetC;
        }
        /// <summary>
        /// Performs difference on 2 given sets.
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        [Route("api/set/Difference")]
        [HttpGet]
        public List<int> Difference([FromBody] SetContainer set)
        {

            foreach (var member in set.SetB)
            {
                if (set.SetA.Contains(member))
                {
                    set.SetA.Remove(member);
                }
            }

            List<int> SetC = set.SetA;

            return SetC;
        }
        /// <summary>
        /// Performs complement on the given set and a given universe.
        /// </summary>
        /// <param name="set"></param>
        /// <returns>Returns a complement of set A.</returns>
        [Route("api/set/Complement")]
        [HttpGet]
        public List<int> Complement([FromBody] SetContainer set)
        {
            foreach (var member in set.SetA)
            {
                if (set.Universe.Contains(member))
                {
                    set.Universe.Remove(member);
                }
            }

            List<int> ModdedUniverse = set.Universe;

            return ModdedUniverse;
        }
        /// <summary>
        /// Handles the 5 methods of subsets and equality in the exercise. If A is a proper-subset of B: Returns -1, if B is a proper-subset of A: Returns 1, if Equal: 0, if neither is a subset and not equal: -2, else 2. 
        /// </summary>
        /// <param name="set"></param>
        /// <returns>Integer with status code.</returns>
        [Route("api/set/Handler")]
        [HttpGet]
        public int Handler([FromBody] SetContainer set)
        {
            int result = 2;
            int subcountChecker = 0;
            int x = 0;
            int notSubsetOfEither = 0;

            // If A is a proper-subset of B
            foreach (var element in set.SetA)
            {
                subcountChecker++;
                if (set.SetB.Contains(element))
                {
                    x++;
                }
                if (x == set.SetA.Count && set.SetA.Count != set.SetB.Count)
                {
                    return -1;
                }

                if (subcountChecker == set.SetA.Count)
                {
                    notSubsetOfEither++;
                }


            }
            subcountChecker = 0;
            x = 0;
            // If B is a proper-subset of A
            foreach (var element in set.SetB)
            {
                subcountChecker++;
                if (set.SetA.Contains(element))
                {
                    x++;
                }
                if (x == set.SetB.Count && set.SetB.Count != set.SetA.Count)
                {
                    return 1;
                }

                if (subcountChecker == set.SetB.Count)
                {
                    notSubsetOfEither++;
                }

            }
            x = 0;
            // if A and B is equal
            if (set.SetA.Count == set.SetB.Count)
            {
                foreach (var element in set.SetB)
                {
                    if (set.SetA.Contains(element))
                    {
                        x++;
                    }
                    if (x == set.SetB.Count)
                    {
                        return 0;
                    }

                }
            }
            x = 0;

            if (notSubsetOfEither == 2)
            {
                return -2;
            }

            return result;
        }
    }
}
