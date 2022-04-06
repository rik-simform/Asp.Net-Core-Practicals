using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical_17.View.Helper;
using Practical_17.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.View.Controllers
{
    public class StudentController : Controller
    {
        StudentAPI studentAPI = new StudentAPI();

        public async Task<IActionResult> Index()
        {
            List<StudentViewVM> students = new List<StudentViewVM>();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students");
            if (res.IsSuccessStatusCode)
            {
                var reslut = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentViewVM>>(reslut);
            }
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            StudentData students = new StudentData();
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/"+id);
            if (res.IsSuccessStatusCode)
            {
                var reslut = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<StudentData>(reslut);
            }
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentData student)
        {
            if (ModelState.IsValid)
            {

                HttpClient client = studentAPI.Initial();
            
                var postdata =  client.PostAsJsonAsync("api/Students",student);
                postdata.Wait();
                var res = postdata.Result;
                if (res.IsSuccessStatusCode)
                {
                   return RedirectToAction(nameof(Index));
                }
              
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            StudentData students = new StudentData();
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/" + id);
            if (res.IsSuccessStatusCode)
            {
                var reslut = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<StudentData>(reslut);
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentData student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    HttpClient client = studentAPI.Initial();

                    var postdata = client.PutAsJsonAsync("api/Students/"+id, student);
                    postdata.Wait();
                    var res = postdata.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            StudentData students = new StudentData();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync("api/Students/" + id);
            return RedirectToAction(nameof(Index));
        }

    }
}
