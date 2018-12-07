using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite {

    public class Question {
        public string QuestionString;
        public string[] Answers;
        public int CorrectAnswer;
        public bool IsAnsweredCorrectly;
    }
}