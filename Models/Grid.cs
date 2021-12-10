using System.Collections.Generic;
using System;
using TetrisApp.Data;
namespace TetrisApp.Models {
    public class Grid{
    public int width = 12;
    public int height = 20;

    public List<int> fullLines = new List<int>();

    public int[,] grid{get;set;}
    public int[,] gridTemp{get;set;}
    public Grid(){
        CreateGrid(this.height, this.width);
    }
    public Grid(int height, int width){
       CreateGrid(height, width);
    }
    public void CreateGrid(int height, int width){
        this.grid=new int[height, width];
        for(int i = 0; i < height; i++){
        for(int j = 0; j < width; j++){
            this.grid[i,j]=0;
            }
        }
        /*TESTS POUR LA GRILLE*/
        for(int x=0;x<width;x++){
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
        this.gridTemp = grid;
        this.CheckFullLines();
    }

    public void AddPiece(Piece piece){
        int[,] gridTemp = (int[,]) this.grid.Clone();        
        // piece.positionY = 3;
        // positionX=5;
        //Il suffit ensuite de bouger positionX et positionY pour bouger la pièce.
        for(int i = 0; i <4;i++){
            for(int j = 0; j <4;j++){
                if(piece.thisPiece[i,j]==1){
                    if(gridTemp[i+piece.positionX, j+piece.positionY]==0){
                        gridTemp[i+piece.positionX, j+piece.positionY]=1;
                    }else{
                        gridTemp[i+piece.positionX, j+piece.positionY]=2;
                    }
                }
            }
        }
        this.grid=gridTemp;
    }

    public void RemoveLines(){
        /*On utilise le tableau fullLines qui comprend les index des lignes pleines*/
        int[,] gridTemp = (int[,]) this.grid.Clone();
        for(int indexLine = 0; indexLine < fullLines.Count; indexLine++){
            /*On part de la ligne pleine pour reremplir le tableau en fonction de ce qu'il y a au dessus*/
            for(int start = fullLines[indexLine]; start>=0; start--){
                for(int x = 0; x < width; x++){
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
        /*on parcourt toutes les lignes du tableau et on supprime si tout est égal à 1.*/
        for(int i=0;i<this.height;i++){
            for(int j=0; j<this.width;j++){
                if(this.grid[i,j]==1){
                    Console.WriteLine("Compteur " + counter);
                    counter++;
                }
            }
            if(counter>10){
                this.fullLines.Add(i);
            }
            counter = 0;
        }

        Console.WriteLine("Nombre de lignes pleines " + fullLines.Count);
    }

    public static int[,] TrimArray(int rowToRemove, int columnToRemove, int[,] originalArray)
        {
            int[,] result = new int[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                    continue;

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                        continue;

                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }

}
}