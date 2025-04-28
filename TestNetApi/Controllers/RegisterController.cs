using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CreateRegisterDataController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CreateRegisterDataController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRegisterData(
    [FromForm] string CompanyName,
    [FromForm] string NPWP,
    [FromForm] string DirectorName,
    [FromForm] string PICName,
    [FromForm] string Email,
    [FromForm] string PhoneNumber,
    [FromForm] bool AllowAccessAfterClosing,
    [FromForm] IFormFile NPWPFilePath,
    [FromForm] IFormFile PowerOfAttorneyFilePath
)
    {
        try
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string npwpSavedPath = null;
            string poaSavedPath = null;

            if (NPWPFilePath != null && NPWPFilePath.Length > 0)
            {
                npwpSavedPath = Path.Combine(uploadsFolder, NPWPFilePath.FileName);
                using (var stream = new FileStream(npwpSavedPath, FileMode.Create))
                {
                    await NPWPFilePath.CopyToAsync(stream);
                }
            }

            if (PowerOfAttorneyFilePath != null && PowerOfAttorneyFilePath.Length > 0)
            {
                poaSavedPath = Path.Combine(uploadsFolder, PowerOfAttorneyFilePath.FileName);
                using (var stream = new FileStream(poaSavedPath, FileMode.Create))
                {
                    await PowerOfAttorneyFilePath.CopyToAsync(stream);
                }
            }

            var registerData = new RegistrationModel
            {
                CompanyName = CompanyName,
                NPWP = NPWP,
                DirectorName = DirectorName,
                PICName = PICName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                AllowAccessAfterClosing = AllowAccessAfterClosing,
                NPWPFilePath = npwpSavedPath,
                PowerOfAttorneyFilePath = poaSavedPath,
                CreatedAt = DateTime.Now
            };

            TryValidateModel(registerData);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.registration.Add(registerData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterData", new { id = registerData.Id }, registerData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetRegisterData(int id)
    {
        var registerData = _context.registration.FirstOrDefault(r => r.Id == id);
        if (registerData == null)
        {
            return NotFound();
        }
        return Ok(registerData);
    }
}
