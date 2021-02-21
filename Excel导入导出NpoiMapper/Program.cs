using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excel导入导出NpoiMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Export();
            Console.WriteLine("执行导出完毕！");
        }
        public static async Task Export()
        {
            IExporter exporter = new ExcelExporter();
            var result = await exporter.Export("a.xlsx", new List<Student>() { 
                new Student { Name = "MR.A", BirthDay = new DateTime(1991, 1, 1) }, 
                new Student { Name = "MR.B", BirthDay = new DateTime(1991, 1, 1) }, 
                new Student { Name = "MR.B", BirthDay = new DateTime(1991, 1, 1) }
            });
        }

    }
}
