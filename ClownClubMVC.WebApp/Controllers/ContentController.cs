using ClownClubMVC.WebApp.Models.ViewModels;
using ClownClubMVC.WebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClownClubMVC.Models.content;
using ClownClubMVC.Business.Services;
using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Business.Services.Content;

namespace ClownClubMVC.WebApp.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IFilmService _filmService;
        private readonly ISerieService _serieService;
        private readonly IPodcastService _podcastService;
        private readonly ITvProgramService _tvProgramService;
        public ContentController(IContentService contentServ, IFilmService filmService, ISerieService serieService, IPodcastService podcastService, ITvProgramService tvProgramService)
        {
            _contentService = contentServ;
            _filmService = filmService; 
            _serieService = serieService;
            _podcastService = podcastService;
            _tvProgramService = tvProgramService;
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
        public async Task<ActionResult> GetContentDetails(int id)
        {
            var response = new Dictionary<string, object>{ };
            var content = await _contentService.GetOne(id);
            if (content == null)
            {
                return NotFound();
            }
            else 
            {
                response.Add("Content", content);
            }
            var film = await _filmService.GetOneByContentId(id);
            if (film != null)
            {
                response.Add("FilmInfo", film);
            }
            var serie = await _serieService.GetOneByContentId(id);
            if (serie != null)
            {
                response.Add("SerieInfo", serie);
            }
            var podcast = await _podcastService.GetOneByContentId(id);
            if (podcast != null)
            {
                response.Add("PodcastInfo", podcast);
            }
            var tvProgram = await _tvProgramService.GetOneByContentId(id);
            if (tvProgram != null)
            {
                response.Add("TvProgramInfo", tvProgram);
            }
            return StatusCode(StatusCodes.Status200OK, response);
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
