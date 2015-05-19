using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using QBox.Api.Client;
using QBox.Api.DTO;
using QBox.Web.Models;

namespace QBox.Web.Controllers
{
    [RoutePrefix("Question")]
    public class QuestionController : Controller
    {
        private readonly IQBoxClient apiClient;

        public QuestionController(IQBoxClient apiClient)
        {
            this.apiClient = apiClient;
        }

        [Route("{category}/{questionNr?}")]
        public ActionResult Index(int category, int questionNr=1, int gameId=0)
        {
            if (questionNr == 1)
            {
                var game = apiClient.StartGame(category,5).Result;
                gameId = game.Id;
            }

            var q = apiClient.GetQuestion(gameId, questionNr).Result;
            if (q != null)
            {
                var questionModel = new QuizQuestionViewModel()
                {
                    Id = q.Id,
                    Category = q.Category,
                    Question = q.Question,
                    QuestionNr = q.QuestionNr,
                    QuestionsTotalNr = q.TotalNrQuestions,
                };
                questionModel.Answers = new List<QuizAnswer>();
                foreach (var a in q.Choices)
                {
                    questionModel.Answers.Add(
                        new QuizAnswer()
                        {
                            Id = a.Id,
                            AnswerText = a.Text
                        });
                }

                return View(questionModel);
            }

            return View("Finished");

            //    var result = this.apiClient.PostResult(model.GameId, model.Answers.Select(a => new AnswerDTO()
            //    {
            //        QuestionId = a.Id,
            //        SelectedAnswer = a.Id
            //    })).Result;

            //    return View("Finished", new QuizResultModel(result));
            //}
            //return View(model);
        }

        [HttpPost]
        [Route("PostAnswer")]
        public async Task<ActionResult> PostAnswer(QuizQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            //TODO: Store answer on backend
            await apiClient.SaveAnswer(model.GameId, model.QuestionNr, model.SelectedAnswer);

            return RedirectToAction("Index", new {category = model.Category, questionNr = model.QuestionNr + 1, gameId = model.GameId});
        }

        [HttpPost]
        [Route("PostScore")]
        public ActionResult PostScore()
        {
            return View();
        }
    }
}