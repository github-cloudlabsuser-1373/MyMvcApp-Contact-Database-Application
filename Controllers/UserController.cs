using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    // GET: User/Search
    public ActionResult Search(string searchTerm)
    {
        // This method is responsible for searching users by name or email.
        var results = userlist.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                          u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        return View(results);
    }
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User

        public ActionResult Index()
        {
            // This method is responsible for displaying the list of users.
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
        return View();
       
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
            // Implement the Create method (POST) here
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Update other properties as needed

                return RedirectToAction(nameof(Index));
            }

            return View(user);
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
            // Implement the Delete method here
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
            return NotFound();
            }

            userlist.Remove(user);
            return RedirectToAction(nameof(Index));
        }
}
