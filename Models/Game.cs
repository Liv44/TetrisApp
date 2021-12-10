using TetrisApp.Models;
namespace TetrisApp.Models{
    public class Game{
        int time{get;set;}
        int score{get;set;}
        int speed{get;set;}
        Grid grille{get;set;}
        public Game(){
            Grid grille = new Grid();
            this.time = 30;
            this.score = 0;
            this.speed = 1;
        }

        public void startGame(){
            
        }
    }
}