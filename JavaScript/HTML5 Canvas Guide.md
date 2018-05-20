# HTML5 Canvas Guide

## Create a Canvas
> drawing the canvas in html, just add the canvas element
``` html
<canvas id="myCanvas" width="200" height="100" style="border:1px solid #000000;">
Your browser does not support the canvas element.
</canvas>
```

## Draw a Rectangle
> drawing a rectangle
``` html
        <canvas id="myCanvasRec" width="200" height="100" style="border:1px solid #c3c3c3;">
                Your browser does not support the canvas element.
        </canvas>

        <script>
                var canvas = document.getElementById("myCanvasRec");
                var ctx = canvas.getContext("2d");
                ctx.fillStyle = "#FF0000";
                ctx.fillRect(0, 0, 150, 75);
        </script>
```

## Draw a Circle
> Define a circle with the arc() method. Then use the stroke() method to actually draw the circle:

``` html
<canvas id="myCanvas3" width="200" height="100" style="border:1px solid #d3d3d3;background:#ffffff;">
                Your browser does not support the HTML5 canvas tag.
        </canvas>
        <script>
                var c = document.getElementById("myCanvas3");
                var canvOK = 1;
                try {
                        c.getContext("2d");
                } catch (er) {
                        canvOK = 0;
                }
                if (canvOK == 1) {
                        var ctx = c.getContext("2d");
                        ctx.beginPath();
                        ctx.arc(95, 50, 40, 0, 2 * Math.PI);
                        ctx.stroke();
                }
        </script>

```
