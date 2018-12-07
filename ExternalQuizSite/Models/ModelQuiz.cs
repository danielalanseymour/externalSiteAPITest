using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite.Models{
    public class ModelQuiz {
        public Quiz Quiz;

        


        public ModelQuiz DefaultQuizModel() {
            GetQuiz get = new GetQuiz();
            return new ModelQuiz() {
                Quiz = get.DefaultQuiz(),
            };
        }



    }
}