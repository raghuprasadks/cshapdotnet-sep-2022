﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonetbasics
{
    internal class DatatablesDemo
    {
        internal static void demoDataTable()
        {
            try
            {
                DataTable employees = new DataTable("employees");



                //    DataColumn id = new DataColumn("id")
                //    {
                //        Caption = "Emp_Id",
                //    DataType = System.Type.GetType("System.Int32"),
                //    AllowDBNull = false,
                //};

                DataColumn id = new DataColumn("id");
                id.Caption = "Emp_Id";
                id.DataType = System.Type.GetType("System.Int32");
                id.AllowDBNull = false;
                id.AutoIncrement = true;
                id.AutoIncrementSeed = 10;
                id.AutoIncrementStep = 5;
                employees.Columns.Add(id);

                DataColumn name = new DataColumn("name");
                name.Caption = "Emp_Name";
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50;
                name.DefaultValue = "Anonymous";
                name.Unique = true;
                employees.Columns.Add(name);

                DataColumn gender = new DataColumn("gender");
                gender.Caption = "Emp_Gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 20;
                employees.Columns.Add(gender);

                DataRow row1 = employees.NewRow();
                //row1["id"] = 1;
                //row1["name"] = "Ali";
                row1["gender"] = "Male";
                employees.Rows.Add(row1);

                employees.Rows.Add(null, "Anum", "Female");
                employees.Rows.Add(null, "Zain", "Male");

                employees.PrimaryKey = new DataColumn[] { id };

                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"]);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }


        internal static void demoCopyNclone()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from employee_tbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable employees = new DataTable();
                sda.Fill(employees);

                Console.WriteLine("Original Data Table");
                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }

                DataTable CopyDataTable = employees.Copy();

                Console.WriteLine("Copy Data Table");
                foreach (DataRow row in CopyDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }

                DataTable CloneDataTable = employees.Clone();

                Console.WriteLine("Clone DataTable");

                if (CloneDataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in CloneDataTable.Rows)
                    {
                        Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                    }

                }
                else
                {
                    //Console.WriteLine("Rows Not Found..");
                    CloneDataTable.Rows.Add(1, "Asif", "Male", 25, 13000, "Karachi");
                    CloneDataTable.Rows.Add(2, "Saba", "Female", 27, 23000, "Sukkur");
                }
                foreach (DataRow row in CloneDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
    }

