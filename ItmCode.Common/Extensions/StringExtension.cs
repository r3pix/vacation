using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Extensions
{
    public static class StringExtension
    {


        public static string ToLikeExpression(this string value) => $"%{value}%";

        public static string ToSqlParameter(this string nullable) => nullable != null ? "'" + nullable + "'" : "NULL";
    }
}