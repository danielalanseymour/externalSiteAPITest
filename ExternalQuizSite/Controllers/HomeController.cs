using ExternalQuizSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalQuizSite.Controllers
{
    public class HomeController : Controller { 


        /**********************************************************************     Logout
          
         **********************************************************************/

        public ActionResult Logout() {
            TempData["QuizSelectionController"] = null;
            TempData["QuizController"] = null;
            TempData["ScoreController"] = null;

            TempData["QuizSelectionView"] = null;
            TempData["QuizView"] = null;
            TempData["ScoreView"] = null;


            return RedirectToAction("QuizSelection");
        }









        /**********************************************************************     Quiz Selection (Home)
          
         **********************************************************************/
        public ActionResult QuizSelection() {
            ModelHome home = new ModelHome();
            home = home.DefaultHome();
           
            return View(home);
        }

        








        /**********************************************************************     Quiz
          
         **********************************************************************/
        public ActionResult Quiz() {
            ModelQuiz quiz = new ModelQuiz();


            if (TempData["QuizController"] != null) {
                quiz = (ModelQuiz)TempData["QuizController"];
                TempData["QuizController"] = null;
            }
            else {
                quiz = quiz.DefaultQuizModel();
            }

            return View(quiz);
        }



        /** *****************************************************     GoToQuiz
          
        ********************************************************/
        public ActionResult GoToQuiz(string quizName) {
            ModelQuiz quiz = new ModelQuiz();
            GetQuiz get = new GetQuiz();


            quiz = quiz.DefaultQuizModel();
            quiz.Quiz = get.DefaultQuiz(quizName);

            TempData["QuizController"] = quiz;
            return RedirectToAction("Quiz");
        }











         /**********************************************************************     Score
          
         **********************************************************************/
        public ActionResult Score() {
            ModelQuiz quiz = new ModelQuiz();


            if (TempData["ScoreController"] != null) {
                quiz = (ModelQuiz)TempData["ScoreController"];
                TempData["ScoreController"] = null;
            }
            else {
                return RedirectToAction("QuizSelection");
            }

            return View(quiz);
        }




        public ActionResult QuizSubmission(int? question1, int? question2, int? question3) {
            
            ModelQuiz quiz = (ModelQuiz)TempData["QuizView"];
            TempData["QuizView"] = null;

            if (question1 != null && ((int)question1 == quiz.Quiz.Questions[0].CorrectAnswer) )
                quiz.Quiz.NumberCorrect++;
            if (question2 != null && ((int)question2 == quiz.Quiz.Questions[1].CorrectAnswer))
                quiz.Quiz.NumberCorrect++;
            if (question3 != null && ((int)question3 == quiz.Quiz.Questions[2].CorrectAnswer))
                quiz.Quiz.NumberCorrect++;
            
            quiz.Quiz.Score = 100.00*((double)quiz.Quiz.NumberCorrect/quiz.Quiz.NumeberOfQuestions);
            



            TempData["ScoreController"] = quiz;
            return RedirectToAction("Score");
        }








        


        /** *****************************************************     GoToQuiz
          
        ********************************************************/
        public ActionResult AccessDatabase(string quizName) {
            ModelQuiz quiz = new ModelQuiz();
            GetQuiz get = new GetQuiz();


            quiz = quiz.DefaultQuizModel();
            quiz.Quiz = get.DefaultQuiz(quizName);

            TempData["QuizController"] = quiz;
            return RedirectToAction("Quiz");
        }










        /**********************************************************************     SuperSecret
          
         **********************************************************************/
        public ActionResult SuperSecret(int id) {

            ModelQuiz quiz = new ModelQuiz();
            GetQuiz get = new GetQuiz();
            if (id >= 0 && id < 10) {
                quiz.Quiz = get.DefaultQuiz(" Quiz " + id);
            }
            else {
                return HttpNotFound();
            }
            return View(quiz);

        }











    }
}