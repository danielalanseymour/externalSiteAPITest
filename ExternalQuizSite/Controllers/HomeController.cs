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
            else if (TempData["QuizView"] != null) {
                quiz = (ModelQuiz)TempData["QuizView"];
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





        /**********************************************************************     QuizSubmission
          
        **********************************************************************/
        public ActionResult QuizSubmission(FormCollection form) {

            if (TempData["QuizView"] == null) {
                RedirectToAction("QuizSelection");
            }


            ModelQuiz modelQuiz = (ModelQuiz)TempData["QuizView"];
            TempData["QuizView"] = null;

            int correctAnswer = 0;
            int selectedAnswer = 0;
            int questionNumberAnswered = 0;

            int numberAnswered = form.Count;
            int numberOfQuestions = modelQuiz.Quiz.Questions.Count;


            try {
                for (int i = 0; i < numberOfQuestions; i++) {
                    selectedAnswer = Convert.ToInt32(form[i]);
                    questionNumberAnswered = Convert.ToInt32(form.AllKeys[i]);

                    for (; i < questionNumberAnswered; i++) {
                        // Mark wrong
                    }

                    correctAnswer = modelQuiz.Quiz.Questions[i].CorrectAnswer;

                    if (selectedAnswer == correctAnswer) {
                        modelQuiz.Quiz.NumberCorrect++;
                    }


                }


                modelQuiz.Quiz.Score = 100.00 * ((double)modelQuiz.Quiz.NumberCorrect / modelQuiz.Quiz.NumeberOfQuestions);
            }
            catch {
                TempData["QuizController"] = modelQuiz;
                return RedirectToAction("Quiz");
            }

            TempData["ScoreController"] = modelQuiz;
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