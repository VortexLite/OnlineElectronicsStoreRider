using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class ImageController : Controller
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile uploadImage, int idProduct)
    {
        if (ModelState.IsValid && uploadImage != null)
        {
            byte[] imageData = null;
            
            using (var memoryStream = new MemoryStream())
            {
                await uploadImage.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            
            var image = new Image()
            {
                IdProduct = idProduct,
                ImageData = imageData
            };

             await _imageService.CreateImageAsync(image);

            return RedirectToAction("Upload");
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPhoto(int id)
    {
        var photo = await _imageService.GetImageAsync(id);

        if (photo == null)
        {
            return NotFound();
        }

        return File(photo.Data.ImageData, "image/webp"); 
    }
}