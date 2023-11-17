using ClownClubMVC.WebApp.Models.ViewModels;
using ClownClubMVC.WebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClownClubMVC.Models.content;
using ClownClubMVC.Business.Services.Interfaces.Content;
using System.Data;

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
                type = c.type,
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
        public async Task<ActionResult> GetContentDetails(int id)
        {
            var response = new Dictionary<string, object> { };
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
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] VMContentComplete modelo, string tipoContenido)
        {
            bool answerTypeOfContent = false;
            try
            {
                content newModel = new content()
                {
                    id = modelo.id,
                    type = modelo.type,
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
                content dataContent = await _contentService.GetOneByTitle(modelo.title);
                switch (tipoContenido.ToLower())
                {
                    case "pelicula":
                        film newFilm = new film()
                        {
                            content_id = dataContent.id,
                            actor = modelo.actor,
                            actress = modelo.actress
                        };
                        answerTypeOfContent = await _filmService.Insert(newFilm);
                        break;
                    case "serie":
                        serie newSerie = new serie()
                        {
                            content_id = dataContent.id,
                            actor = modelo.actor,
                            actress = modelo.actress
                        };
                        answerTypeOfContent = await _serieService.Insert(newSerie);
                        break;
                    case "podcast":
                        podcast newPodcast = new podcast()
                        {
                            content_id = dataContent.id,
                            presenter = modelo.presenter,
                            collaborator = modelo.collaborator
                        };
                        answerTypeOfContent = await _podcastService.Insert(newPodcast);
                        break;
                    case "tvProgram":
                        tvProgram newTvProgram = new tvProgram()
                        {
                            content_id = dataContent.id,
                            presenter = modelo.presenter,
                            collaborator = modelo.collaborator
                        };
                        answerTypeOfContent = await _tvProgramService.Insert(newTvProgram);
                        break;
                }
                bool answer = answercontent && answerTypeOfContent;
                return StatusCode(StatusCodes.Status200OK, new { valor = answer });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] VMContentComplete modelo, string tipoContenido)
        {
            bool answerTypeOfContent = false;
            content newModel = new content()
            {
                id = modelo.id,
                type = modelo.type,
                title = modelo.title,
                duration = modelo.duration,
                size = modelo.size,
                viewsContent = modelo.viewsContent,
                languageContent = modelo.languageContent,
                formatContent = modelo.formatContent,
                producer = modelo.producer,
                imageUrl = modelo.imageUrl
            };
            bool answerContent = await _contentService.Update(newModel);
            content dataContent = await _contentService.GetOne(modelo.id);
            if (dataContent != null)
            {
                dataContent.type = modelo.type;
                dataContent.title = modelo.title;
                dataContent.duration = modelo.duration;
                dataContent.size = modelo.size;
                dataContent.viewsContent = modelo.viewsContent;
                dataContent.languageContent = modelo.languageContent;
                dataContent.formatContent = modelo.formatContent;
                dataContent.producer = modelo.producer;
                dataContent.imageUrl = modelo.imageUrl;
                switch (tipoContenido.ToLower())
                {
                    case "pelicula":
                        film existingFilm = await _filmService.GetOneByContentId(dataContent.id);
                        if (existingFilm != null)
                        {
                            existingFilm.actor = modelo.actor;
                            existingFilm.actress = modelo.actress;
                            answerTypeOfContent = await _filmService.Update(existingFilm);
                        }
                        break;
                    case "serie":
                        serie existingSerie = await _serieService.GetOneByContentId(dataContent.id);
                        if (existingSerie != null)
                        {
                            existingSerie.actor = modelo.actor;
                            existingSerie.actress = modelo.actress;
                            answerTypeOfContent = await _serieService.Update(existingSerie);
                        }
                        break;
                    case "podcast":
                        podcast existingPodcast = await _podcastService.GetOneByContentId(dataContent.id);
                        if (existingPodcast != null)
                        {
                            existingPodcast.presenter = modelo.presenter;
                            existingPodcast.collaborator = modelo.collaborator;
                            answerTypeOfContent = await _podcastService.Update(existingPodcast);
                        }
                        break;
                    case "tvprogram":
                        tvProgram existingTvProgram = await _tvProgramService.GetOneByContentId(dataContent.id);
                        if (existingTvProgram != null)
                        {
                            existingTvProgram.presenter = modelo.presenter;
                            existingTvProgram.collaborator = modelo.collaborator;
                            answerTypeOfContent = await _tvProgramService.Update(existingTvProgram);
                        }
                        break;
                }
            }
            bool answer = answerContent && answerTypeOfContent;
            return StatusCode(StatusCodes.Status200OK, new { valor = answer });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            bool answerTypeOfContent = false;
            content dataContent = await _contentService.GetOne(id);
            switch (dataContent.type)
            {
                case "pelicula":
                    answerTypeOfContent = await _filmService.Delete(id);
                    break;
                case "serie":
                    answerTypeOfContent = await _serieService.Delete(id);
                    break;
                case "podcast":
                    answerTypeOfContent = await _podcastService.Delete(id);
                    break;
                case "tvProgram":
                    answerTypeOfContent = await _tvProgramService.Delete(id);
                    break;
            }
            bool answerContent = await _contentService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = answerContent && answerTypeOfContent });
        }
        public IActionResult ContentManage()
        {
            return View();
        }
        public IActionResult ContentView()
        {
            return View();
        }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
