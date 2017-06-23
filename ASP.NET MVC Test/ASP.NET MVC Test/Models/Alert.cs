using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Test.Models
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
        public string Glyphicon { get; set; }
        public bool Dismissable { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }

    public static class Glyphicons
    {
        public const string Success = "glyphicon-ok";
        public const string Information = "glyphicon-info-sign";
        public const string Warning = "glyphicon-exclamation-sign";
        public const string Danger = "glyphicon-remove";
    }

    public static class AlertTittles
    {
        public const string Success = "¡Éxito! ";
        public const string Information = "Información ";
        public const string Warning = "Atención ";
        public const string Danger = "Peligro ";
    }
}