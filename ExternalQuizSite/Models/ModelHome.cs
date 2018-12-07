using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite.Models { 
    public class ModelHome {
        public List<string> Quizzes;



        /**********************************************************************     Default Home Model
          
         **********************************************************************/
        public ModelHome DefaultHome() {
            GetQuiz get = new GetQuiz();
            return new ModelHome() {
                Quizzes= get.QuizNames(),
            };
        }

        
       







    }
}