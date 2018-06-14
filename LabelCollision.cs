using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapControl
{
    public class LabelCollisionDetection
    {
        #region Delegates

        /// <summary>
        /// Delegate method for filtering labels. Useful for performing custom collision detection on labels
        /// </summary>
        /// <param name="labels"></param>
        /// <returns></returns>
        public delegate void LabelFilterMethod(List<BaseLabel> labels);

        #endregion

        #region Label filter methods

        /// <summary>
        /// Simple and fast label collision detection.
        /// </summary>
        /// <param name="labels"></param>
        public static void SimpleCollisionDetection(List<BaseLabel> labels)
        {
            labels.Sort(); // sort labels by intersectiontests of labelbox
            //remove labels that intersect other labels
            for (int i = labels.Count - 1; i > 0; i--)
                if (labels[i].CompareTo(labels[i - 1]) == 0)
                {
                    if (labels[i].Priority == labels[i - 1].Priority) continue;

                    if (labels[i].Priority > labels[i - 1].Priority)
                        labels.RemoveAt(i - 1);
                    else
                        labels.RemoveAt(i);
                }
        }
        #endregion
    }
}