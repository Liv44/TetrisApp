using System.Collections.Generic;
using System;
using TetrisApp.Data;
namespace TetrisApp.Models {
    public class Grid{
    public int largeur = 10;
    public int hauteur = 20;

    public List<int> fullLines = new List<int>();

    public int[,] grid{get;set;}
    public int[,] gridTemp{get;set;}
    public Grid(){
        CreateGrid(this.hauteur, this.largeur);
    }
    public Grid(int hauteur, int largeur){
       CreateGrid(hauteur, largeur);
    }
    public void CreateGrid(int hauteur, int largeur){
        this.grid=new int[hauteur, largeur];
        for(int i = 0; i < hauteur; i++){
        for(int j = 0; j < largeur; j++){
            this.grid[i,j]=0;
            }
        }
       
        this.gridTemp = grid;
        this.CheckFullLines();
    }

    public void AddPiece(Piece piece){
        this.gridTemp = (int[,]) this.grid.Clone();        
        //Il suffit ensuite de bouger positionX et positionY pour bouger la pièce.
        for(int i = 0; i <4;i++){
            for(int j = 0; j <4;j++){
                if(piece.thisPiece[i,j]==1 ){
                    this.gridTemp[i+piece.positionX, j+piece.positionY]=1;
                }
            }
        }
    }
    public void DropPiece(Piece piece){
        /*On check la hauteur de la pièce pour la poser soir positionX*/
        for(int indexHauteur = hauteur-1; indexHauteur >0;indexHauteur--){
            if(this.grid[indexHauteur, piece.positionY]==0){
                Console.WriteLine(indexHauteur);
                piece.positionX=indexHauteur-2;
                break;
            }
        }
        // piece.positionX=17;
        for(int i = 0; i <4;i++){
            for(int j = 0; j <4;j++){
                if(piece.thisPiece[i,j]==1 ){

                    this.grid[i+piece.positionX, j+piece.positionY]=1;
                }
            }
        }
    }
    public void RemoveLines(){
        /*On utilise le tableau fullLines qui comprend les index des lignes pleines*/
        this.gridTemp = (int[,]) this.grid.Clone();
        for(int indexLine = 0; indexLine < fullLines.Count; indexLine++){
            /*On part de la ligne pleine pour reremplir le tableau en fonction de ce qu'il y a au dessus*/
            for(int start = fullLines[indexLine]; start>=0; start--){
                for(int x = 0; x < largeur; x++){
                    if(start==0){
                     this.gridTemp[start,x] =0;   
                    } else{
                    this.gridTemp[start,x] = this.gridTemp[start-1,x];
                    }
                }
            }
        }

        this.grid = this.gridTemp;

        this.fullLines.RemoveAll(x => x > -1);
        /*Permet de nettoyer le tableau qui contient les lignes pleines*/
    }

    public void CheckFullLines(){
        int counter = 0;
        /*on parcourt toutes les lignes du tableau et on ajoute l'index de la ligne si tout est égal à 1.*/
        for(int i=0;i<this.hauteur;i++){
            for(int j=0; j<this.largeur;j++){
                if(this.grid[i,j]==1){
                    counter++;
                }
            }
            if(counter>=10){
                this.fullLines.Add(i);
                
            }
            counter = 0;
        }
    }

    public void TestLignes(){
        /*TESTS POUR LA GRILLE*/
        for(int x=0;x<largeur;x++){
            this.grid[19,x]=1;
            this.grid[5,x]=1;
            this.grid[18,x]=1;
            this.grid[6,7]=1;
            this.grid[6,8]=1;
            this.grid[6,9]=1;
            this.grid[10,7]=1;
            this.grid[10,8]=1;
            this.grid[10,9]=1;
            this.grid[0,5]=1;         
        }
    }

    }
}