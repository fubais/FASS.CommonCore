namespace FASS.CommonCore
{
    using System.Data;

    public static class DataExt
    {
        public static string ToString(this DataRow row, string strColName, string errorValue = "")
        {
            if (row == null|| string.IsNullOrEmpty(strColName)|| row.Table.IsNullOrEmpty())
                return errorValue;

            if (row.Table.Columns.Contains(strColName) && !row.IsNull(strColName))
            {
                return row[strColName].ToString();
            }
            return errorValue;
        }


        public static bool ToBool(this DataRow row, string strColName,bool errorValue=false)
        {
            if (row == null || string.IsNullOrEmpty(strColName) || row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName) || row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToBool(errorValue);
        }


        public static byte ToByte(this DataRow row, string strColName, byte errorValue = 0)
        {
            if (row == null || string.IsNullOrEmpty(strColName) || row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName) || row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToByte(errorValue);
        }



        public static int ToInt(this DataRow row, string strColName, int errorValue = 0)
        {
            if (row == null || string.IsNullOrEmpty(strColName)|| row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName)|| row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToInt(errorValue);
        }




        public static long ToLong(this DataRow row, string strColName, long errorValue = 0)
        {
            if (row == null || string.IsNullOrEmpty(strColName) || row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName) || row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToLong(errorValue);
        }



        public static float ToSingle(this DataRow row, string strColName, float errorValue = 0)
        {
            if (row == null || string.IsNullOrEmpty(strColName) || row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName) || row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToSingle(errorValue);
        }


        public static double ToDouble(this DataRow row, string strColName, double errorValue = 0)
        {
            if (row == null || string.IsNullOrEmpty(strColName) || row.Table.IsNullOrEmpty() || !row.Table.Columns.Contains(strColName) || row.IsNull(strColName))
                return errorValue;

            return row[strColName].ObjToDouble(errorValue);
        }

        public static bool IsNullOrEmpty(this DataTable table)
        {
            if (table == null)
                return true;

            if (table.Rows?.Count == 0)
                return true;

            return false;

        }


        public static bool IsNullOrEmpty(this DataSet set)
        {
            if (set == null)
                return true;

            if (set.Tables?.Count <= 0)
                return true;

            foreach (DataTable table in set.Tables)
            {
                if (!IsNullOrEmpty(table))
                {
                    return false;
                }
            }

            return true;
        }


    }
}
