#pragma strict

 //TEXTURE SETTINGS
 var texWidth : int = 512;
 var texHeight : int = 512;
 
 //MASK SETTINGS
 var maskThreshold : float = 2.0;
 
 //REFERENCES
 var mask : Texture2D;
 
 function Start(){
     GenerateTexture();    
 }
 
 function GenerateTexture(){
 
     mask = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, true);
     var maskCenter : Vector2 = new Vector2(texWidth * 0.5, texHeight * 0.5);
        
     for(var y : int = 0; y < mask.height; ++y){
         for(var x : int = 0; x < mask.width; ++x){
 
             var distFromCenter : float = Vector2.Distance(maskCenter, new Vector2(x, y));
             var maskPixel : float = (0.5 - (distFromCenter / texWidth)) * maskThreshold;
             mask.SetPixel(x, y, Color(maskPixel, maskPixel, maskPixel, 1.0));
         }
     }
     mask.Apply();
 }