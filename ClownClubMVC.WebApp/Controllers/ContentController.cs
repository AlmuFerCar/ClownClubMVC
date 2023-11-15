using ClownClubMVC.Business.Services.Interfaces;
using ClownClubMVC.WebApp.Models.ViewModels;
using ClownClubMVC.WebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.WebApp.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentServ)
        {
            _contentService = contentServ;
        }
        public IActionResult ContentManage()
        {
            return View();
        }
        public IActionResult ContentView()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<ActionResult> ListView()
        {
            IQueryable<content> queryContentSQL = await _contentService.GetAll();
            List<VMContent> list = queryContentSQL.Select(c => new VMContent()
            {
                id = c.id,
                title = c.title,
                duration = c.duration,
                viewsContent = c.viewsContent,
                languageContent = c.languageContent,
                imageUrl = c.imageUrl
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }
        [HttpGet]
        public async Task<ActionResult> List()
        {
            IQueryable<content> queryContentSQL = await _contentService.GetAll();
            List<VMContent> list = queryContentSQL.Select(c => new VMContent()
            {
                id = c.id,
                title = c.title,
                duration = c.duration,
                size = c.size,
                viewsContent = c.viewsContent,
                languageContent = c.languageContent,
                formatContent = c.formatContent,
                producer = c.producer,
                imageUrl = c.imageUrl}).ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] VMContent modelo)
        {
            try
            {
                content newModel = new content()
                {
                    id = modelo.id,
                    title = modelo.title,
                    duration = modelo.duration,
                    size = modelo.size,
                    viewsContent = modelo.viewsContent,
                    languageContent = modelo.languageContent,
                    formatContent = modelo.formatContent,
                    producer = modelo.producer,
                    imageUrl = modelo.imageUrl
                };
                bool answercontent = await _contentService.Insert(newModel);
                return StatusCode(StatusCodes.Status200OK, new { valor = answercontent });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] VMContent modelo)
        {
            content newModel = new content()
            {
                id = modelo.id,
                title = modelo.title,
                duration = modelo.duration,
                size = modelo.size,
                viewsContent = modelo.viewsContent,
                languageContent = modelo.languageContent,
                formatContent = modelo.formatContent,
                producer = modelo.producer,
                imageUrl = modelo.imageUrl
            };
            bool answer = await _contentService.Update(newModel);
            return StatusCode(StatusCodes.Status200OK, new { valor = answer });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            bool answerContent = await _contentService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = answerContent });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
