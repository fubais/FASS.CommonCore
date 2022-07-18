namespace FASS.CommonCore
{
    using System;

    public static class ValueConvertExt
    {
        public static bool ObjToBool(this object obj, bool errorValue = false)
        {
            bool value = false;
            if (obj != null && obj != DBNull.Value )
            {
                if (bool.TryParse(obj.ToString(), out value))
                    return value;

                if (obj.ObjToInt() > 0)
                    return true;
            }
            return errorValue;
        }


        public static byte ObjToByte(this object obj, byte errorValue =0)
        {
            byte value = 0;
            if (obj != null && obj != DBNull.Value && byte.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }


        public static int ObjToInt(this object obj, int errorValue =0)
        {
            if (obj is Enum)
            {
                return (int)obj;
            }

            int value = 0;
            if (obj != null && obj != DBNull.Value && int.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }


        public static long ObjToLong(this object obj, long errorValue = 0)
        {
            if (obj is Enum)
            {
                return (int)obj;
            }

            long value = 0;
            if (obj != null && obj != DBNull.Value && long.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }


        public static float ObjToSingle(this object obj, float errorValue = 0)
        {
            float value = 0;
            if (obj != null && obj != DBNull.Value && float.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }


        public static double ObjToDouble(this object obj, double errorValue = 0)
        {
            double value = 0;
            if (obj != null && obj != DBNull.Value && double.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }



        public static DateTime ObjToDateTime(this object obj, DateTime errorValue = default(DateTime))
        {
            DateTime value = default(DateTime);
            if (obj != null && obj != DBNull.Value && DateTime.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }

        public static TimeSpan ObjToTimeSpan(this object obj, TimeSpan errorValue = default(TimeSpan))
        {
            TimeSpan value = default(TimeSpan);
            if (obj != null && obj != DBNull.Value && TimeSpan.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return errorValue;
        }



    }
}
