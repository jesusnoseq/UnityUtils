using System.Collections;
using System;

namespace com.jesusnoseq.util
{
    public static class CollectionUtils {
        public static int IndexOf<T>(this T[] array, T item) {
            return Array.IndexOf(array, item);
        }

        public static int IndexOfOrZero<T>(this T[] array, T item) {
            int idx=Array.IndexOf(array, item);
            if (idx <0){
                return 0;
            }
            return idx;
        }
    }

}