using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite.Models{
    public class GetQuiz {






        
        /**********************************************************************     Default Quiz
          
        ***********************************************************************/
        public Quiz DefaultQuiz(string quizName) {

            Quiz quiz = new Quiz() {
                QuizName = quizName,
                NumberCorrect = 0,
                NumeberOfQuestions = 0,
                Score = 0,
                Questions = new List<Question>()
            };
            string question1 = "Test Question 1";
            string question2 = "Test Question 2";
            string question3 = "Test Question 3";
            string answer1 = "1st Answer";
            string answer2 = "2nd Answer";
            string answer3 = "3rd Answer";
            string answer4 = "4th Answer";

            quiz.Questions.Add( new Question() {
                QuestionString = question1,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );
            quiz.Questions.Add( new Question() {
                QuestionString = question2,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );
            quiz.Questions.Add( new Question() {
                QuestionString = question3,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );

            quiz.NumeberOfQuestions = quiz.Questions.Count;

            return quiz;
        }





        /**********************************************************************     Default Quiz
          
        ***********************************************************************/
        public Quiz DefaultQuiz() {

            Quiz quiz = new Quiz() {
                QuizName = "Default Quiz",
                NumberCorrect = 0,
                NumeberOfQuestions = 0,
                Score = 0,
                Questions = new List<Question>()
            };
            string question1 = "Test Question 1";
            string question2 = "Test Question 2";
            string question3 = "Test Question 3";
            string answer1 = "1st Answer";
            string answer2 = "2nd Answer";
            string answer3 = "3rd Answer";
            string answer4 = "4th Answer";

            quiz.Questions.Add( new Question() {
                QuestionString = question1,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );
            quiz.Questions.Add( new Question() {
                QuestionString = question2,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );
            quiz.Questions.Add( new Question() {
                QuestionString = question3,
                Answers = new string[] { answer1, answer2, answer3, answer4 },
                CorrectAnswer = 2,
                IsAnsweredCorrectly = false
            } );


            quiz.NumeberOfQuestions = quiz.Questions.Count;
            return quiz;
        }






        /**********************************************************************     Default Quiz
          
        ***********************************************************************/
        public List<string> QuizNames() {
            List<string> list = new List<string>();
            
            for (int i = 1; i < 10; i ++) {
                list.Add("Quiz #" + i);
            }

            return list;
        }




    }
}