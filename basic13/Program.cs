using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr2= {2,3,4,1,0};
            int[] arr3 = {-1,2};
            Console.WriteLine("Hello World!");

            Print255();
            PrintOdd();
            PrintSum();
            Iterate(arr2);
            Max(arr2);
            Avg(arr2);
            Yessir();
            Greater(arr2);
            Square(arr2);
            // Eliminate(arr3);
            MaxMinAvg(arr2);
            Shifty(arr2);
            object[] boxedArray = new object[]{-1,3,2,-16};
            NtoS(boxedArray);
            

        }
        

        public static void Print255(){
            for(int i = 1; i <256; i++){
                Console.WriteLine(i);
            }
        }
        public static void PrintOdd(){
            for(int i = 1; i<256; i++){
                if(i % 2 == 1){
                    System.Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum(){
            int sum = 0;
            for(int i = 0; i<256; i++){
                sum += i;
            }
            System.Console.WriteLine(sum);
        }

        public static void Iterate(int[] arr){
            for(int i  = 0; i< arr.Length; i++){
                Console.WriteLine(arr[i]);
            }

        }
        public static void Max(int[] arr){
            int Max= arr[0];
            for(int i = 0; i< arr.Length; i++){
                if (Max < arr[i]){
                    Max = arr[i];
                }
            }
            System.Console.WriteLine(Max);
        }
        
        public static void Avg(int[] arr){
            int sum = 0;
            for(int i = 0; i <arr.Length; i++){
                sum += i;
            }
            System.Console.WriteLine(sum/arr.Length);
        }

        public static void Yessir(){
            List<int> y = new List<int>();
            y.ToArray();
            for(int i = 0; i<256; i++){
                if(i % 2 == 1){
                    y.Add(i);
                }
            }
            System.Console.WriteLine(y);            
        }
        public static void Greater(int[] arr,int y =3){
            for(int i= 0; i<arr.Length; i++){
                if(arr[i]> y){
                    System.Console.WriteLine(arr[i]);
                }
            }
        }
        public static void Square(int[] arr){
            List<int> sq = new List <int>();
            sq.ToArray();
            for(int i = 0; i<arr.Length; i++){
                arr[i] = arr[i] * arr[i];
                System.Console.WriteLine(arr[i]);
                sq.Add(arr[i]);
            }
        }
        public static void Eliminate(int[] arr){
            for(int i =0; i<arr.Length; i++){
                if(arr[i] < 0){
                    arr[i] = 0;
                }
                System.Console.WriteLine(arr);
            }
        }
        public static void MaxMinAvg(int[] arr){
            int max = arr[0];
            int min = arr[0];
            int sum = 0;

            for(int i = 0; i<arr.Length; i++){
                
                if(arr[i] > max){
                    max = arr[i];
                }
                if(arr[i]< min){
                    min = arr[i];
                }
                sum += arr[i];
            }
            int avg = sum/arr.Length;
            System.Console.WriteLine(max);
            System.Console.WriteLine(min);
            System.Console.WriteLine(avg);
        }
        public static void Shifty(int[] arr){
            int temp = arr[arr.Length-1];
            for(int i = arr.Length-1; i>0; i--){
                 temp = arr[i];
                 arr[i] = arr[i -1];


            }
            arr[0] = temp;
        }
        public static object[] NtoS(object[] arr){
            for(int i = 0; i < arr.Length; i++){
                if((int)arr[i] < 0){
                    arr[i] = "DOJO";
                }
            }
            return arr;
        }

    }
}
