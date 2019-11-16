using MescytIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MescytIntegration.Controllers
{
    public class IntegrationController : Controller
    {
        // GET: Integration
        public Object Index()
        {
            MescytIntegrationDbContext db = new MescytIntegrationDbContext();
            return db.NewStudents;
        }

        // GET: Integration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Integration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Integration/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            //var file = collection[0];
            try
            {
               
                XmlDocument doc = new XmlDocument();
                List<NewStudentsFat> newStudents = new List<NewStudentsFat>();
                NewStudentsFat newStudent = new NewStudentsFat();
                Student student = new Student();
                Carreer carreer = new Carreer();
                University uni = new University();


                doc.Load(file.InputStream);
                XmlNode node = doc.SelectSingleNode("nuevosEstudiantes");

                XmlNodeList newStudentList = node.SelectNodes("nuevoEstudiante");
                MescytIntegrationDbContext db = new MescytIntegrationDbContext();
                

                foreach (XmlNode item in newStudentList)
                {

                    newStudent.period = item["periodo"].InnerText;

                    student.StudentID = item["matricula"].InnerText;
                    student.FirstName = item["nombre"].InnerText;
                    student.FirstLastName = item["primerApellido"].InnerText;
                    student.SecondLastName = item["segundoApellido"].InnerText;
                    student.Gender = item["sexo"].InnerText;
                    student.Birthday = Convert.ToDateTime(item["fechaNacimiento"].InnerText);
                    student.Genmunicipality = item["municipio"].InnerText;
                    student.CountryOfBirth = item["paisNacimiento"].InnerText;
                    student.CountryBeforeStartStudying = item["paisRecidenciaPrevioEstudio"].InnerText;

                    newStudent.Student = student;

                    carreer.Name = item["carrera"].InnerText;
                    carreer.Code = item["codigoCarrera"].InnerText;
                    carreer.Modality = item["modalidad"].InnerText;

                    newStudent.Carreer = carreer;

                    uni.name = item["universidad"].InnerText;
                    uni.acronym = item["siglas"].InnerText;

                    newStudent.University = uni;

                    newStudents.Add(newStudent);

                    db.NewStudents.Add(newStudent);
                    db.SaveChanges();

                    /* newStudents.Add(new NewStudentsFat()
                    {
                        
                        period = node["periodo"].InnerText,
                        //UniversityID = 0,
                        //CarreerID = 0,
                        //StudentID = 0,
                        
                       University = new University()
                        {
                            name = node["universidad"].InnerText,
                            acronym = node["acronym"].InnerText,

                        },

                        Student = new Student()
                        {
                            StudentID = node["matricula"].InnerText,
                            FirstName = node["nombre"].InnerText,
                            FirstLastName = node["primerApellido"].InnerText,
                            SecondLastName = node["segundoApellido"].InnerText,
                            Gender = node["sexo"].InnerText,
                            Birthday = Convert.ToDateTime(node["fechaNacimiento"].InnerText),
                            Genmunicipality = node["municipio"].InnerText,
                            CountryOfBirth = node["paisNacimiento"].InnerText,
                            CountryBeforeStartStudying = node["paisRecidenciaPrevioEstudio"].InnerText,
                        
                        },

                        Carreer = new Carreer()
                        { 
                            Name = node["carrera"].InnerText,
                            Code = node["codigoCarrera"].InnerText,
                            Modality = node["modalidad"].InnerText,


                        },
                        

                    });*/

                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: Integration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Integration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Integration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Integration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
