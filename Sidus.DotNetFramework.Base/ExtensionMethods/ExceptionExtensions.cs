using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ExceptionExtensions
    {
        /// <summary>
        /// Returns a list of all the exception messages from the top-level
        /// exception down through all the inner exceptions. Useful for making
        /// logs and error pages easier to read when dealing with exceptions.
        /// Usage: Exception.Messages()
        /// </summary>
        public static IEnumerable<string> ToMessages(this Exception ex)
        {
            // return an empty sequence if the provided exception is null
            if (ex == null) { yield break; }
            // first return THIS exception's message at the beginning of the list
            yield return ex.Message;
            // then get all the lower-level exception messages recursively (if any)
            IEnumerable<Exception> innerExceptions = Enumerable.Empty<Exception>();

            if (ex is AggregateException && (ex as AggregateException).InnerExceptions.Any())
            {
                innerExceptions = (ex as AggregateException).InnerExceptions;
            }
            else if (ex.InnerException != null)
            {
                innerExceptions = new Exception[] { ex.InnerException };
            }

            foreach (var innerEx in innerExceptions)
            {
                foreach (string msg in innerEx.ToMessages())
                {
                    yield return msg;
                }
            }
        }

        public static string ToInnerExceptionMessage(this Exception ex)
        {
            var returnMessage = "Hata mesajı bulunamadı";
            if (ex == null)
            {
                //do nothing
            }
            else if (ex.InnerException == null)
            {
                var loaderEx = ex as ReflectionTypeLoadException;
                var dbException = ex as System.Data.Common.DbException;
                if (loaderEx != null)
                {
                    var sb = new StringBuilder();
                    foreach (var item in loaderEx.LoaderExceptions)
                    {
                        sb.AppendLine(item.Message);
                    }
                    returnMessage = sb.ToString();
                }
                else if (false)
                {
                    //TODO: ef exceptions
                    // returnMessage = dbException.Message;
                }
                else
                {
                    returnMessage = ex.Message;
                }
            }
            else
            {
                returnMessage = ex.InnerException.ToInnerExceptionMessage();
            }

            return returnMessage;
        }

        /// <summary>
        /// Gets the most inner (deepest) exception of a given Exception object
        /// </summary>
        /// <param name="ex">Source Exception</param>
        /// <returns></returns>
        public static Exception ToMostInner(this Exception ex)
        {
            Exception ActualInnerEx = ex;

            while (ActualInnerEx != null)
            {
                ActualInnerEx = ActualInnerEx.InnerException;
                if (ActualInnerEx != null)
                    ex = ActualInnerEx;
            }
            return ex;
        }
    }
}
