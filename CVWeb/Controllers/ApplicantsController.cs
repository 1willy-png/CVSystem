using Microsoft.AspNetCore.Mvc;
using CVSystem.Models;
using System.IO;
using CVSystem.Data;

public class ApplicantsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ApplicantsController(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public IActionResult Apply()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Apply(Applicant applicant, IFormFile cvFile)
    {
        if (cvFile != null)
        {
            var folder = Path.Combine(_environment.WebRootPath, "uploads/cvs");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cvFile.FileName);

            var filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await cvFile.CopyToAsync(stream);
            }

            applicant.CvFilePath = "/uploads/cvs/" + fileName;

            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }
}