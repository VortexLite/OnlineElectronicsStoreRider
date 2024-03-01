using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.ViewModels.Category;
using OnlineElectronicsStore.Models;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var response = await _categoryService.GetCategories();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data.ToList());
        }

        return RedirectToAction("Error");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategory(int id)
    {
        var response = await _categoryService.GetCategory(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await _categoryService.DeleteCategory(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetCategories");
        }

        return RedirectToAction("Error");
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0)
        {
            return View();
        }
        var response = await _categoryService.GetCategory(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [HttpPost]
    public async Task<IActionResult> Save(CategoryViewModel categoryViewModel)
    {
        if (ModelState.IsValid)
        {
            if (categoryViewModel.Id == 0)
            {
                await _categoryService.CreateCategory(categoryViewModel);
            }
            else
            {
                await _categoryService.EditCategory(categoryViewModel);
            }
        }

        return RedirectToAction("GetCategories");
    }
}