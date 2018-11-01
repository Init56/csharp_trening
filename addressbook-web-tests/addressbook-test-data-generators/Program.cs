using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressBookTests;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string data = args[3];

            if (data == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        GroupHeader = TestBase.GenerateRandomString(10),
                        GroupFooter = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteGroupsToCSVFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXMLFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        Console.WriteLine($"Формат {format} не распознан");
                    }
                    writer.Close();
                }

            }
            else if (data == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                    {
                        Address = TestBase.GenerateRandomString(100),
                        HomePhone = TestBase.GenerateRandomString(20),
                        Email = TestBase.GenerateRandomString(20)
                    });
                }
                if (format == "excel")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteContactsToCSVFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXMLFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        Console.WriteLine($"Формат {format} не распознан");
                    }
                    writer.Close();
                }
                }
            else
            {
                    Console.WriteLine($"Тип данных {data} не распознан");
            }           
           
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.GroupName;
                sheet.Cells[row, 2] = group.GroupHeader;
                sheet.Cells[row, 3] = group.GroupFooter;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Middlename;
                sheet.Cells[row, 3] = contact.Lastname;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                group.GroupName, group.GroupHeader, group.GroupFooter));
            }
        }
        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToCSVFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4}",
                contact.Firstname, contact.Lastname, contact.Address, contact.HomePhone, contact.Email));
            }
        }
        static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}