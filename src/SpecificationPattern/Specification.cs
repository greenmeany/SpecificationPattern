using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace SpecificationPattern
{
    /// <summary>
    /// Determines if an object meets a specification
    /// </summary>
    public class Specification<T>
    {

        /// <summary>
        /// Predicate that checks an object satisfies a given specification
        /// </summary>
        public Expression<Func<T, bool>> Predicate { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="specification">Specification as a bool</param>
        public Specification(Expression<Func<T,bool>> specification)
        {
            Predicate = specification;
        }

        /// <summary>
        /// New specifiaction where candidates must satisfy this AND the new specification
        /// </summary>
        /// <param name="other">Other Specification</param>
        /// <returns>New specification</returns>
        public Specification<T> And(Expression<Func<T,bool>> other)
        {          
            return new Specification<T>(Predicate.And(other));
        }

        /// <summary>
        /// Builds new specification where candidates must satisfy this OR the new specification
        /// </summary>
        /// <param name="other">Other Specification</param>
        /// <returns>New specification</returns>
        public Specification<T> Or(Expression<Func<T, bool>> other)
        {
            return new Specification<T>(Predicate.Or(other));
        }

        /// <summary>
        /// Determines if candidate meets the specified criteria
        /// </summary>
        /// <param name="candidate">Candidate to evaluate</param>
        /// <returns></returns>
        public bool IsSatisfiedBy(T candidate)
        {
            return Predicate.Compile().Invoke(candidate);
        }


    }
}
