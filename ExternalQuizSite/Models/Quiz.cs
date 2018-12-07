using ExternalQuizSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite {


    /**********************************************************************     Quiz Model

     **********************************************************************/

    public class Quiz {
        public string QuizName;
        public List<Question> Questions;
    //public Question[] Questions;
        public int NumberCorrect;
        public int NumeberOfQuestions;
        public double Score;




        
        public Quiz DefaultQuiz() {
            GetQuiz get = new GetQuiz();
            return get.DefaultQuiz();
        }
    }
}