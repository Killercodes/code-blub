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

## Draw a Circle glow
> Use the shadow attribute for blur
``` html
        <canvas id="myCanvas3g" width="400" height="200" style="border:1px solid #d3d3d3;background:#ffffff;">
                Your browser does not support the HTML5 canvas tag.
        </canvas>
        <script>
                var c = document.getElementById("myCanvas3g");
                var canvOK = 1;
                try {
                        c.getContext("2d");
                } catch (er) {
                        canvOK = 0;
                }
                if (canvOK == 1) {
                        var ctx = c.getContext("2d");
                        ctx.fillStyle = "black";
                        ctx.fillRect(0, 0, 400, 200);
                        ctx.beginPath();
                        ctx.arc(95, 50, 40, 0, 2 * Math.PI);
                        ctx.arc(195, 50, 10, 0, 2 * Math.PI);
                        ctx.shadowBlur = 40;
                        ctx.shadowOffsetY = 0;
                        ctx.shadowOffsetX = 0;
                        ctx.shadowColor = "#53FFFF";
                        //ctx.stroke();
                        // Create gradient
                        var grd = ctx.createRadialGradient(75, 50, 5, 90, 60, 100);
                        grd.addColorStop(0, "#53FFFF");
                        grd.addColorStop(1, "#DBFFFF");

                        // Fill with gradient
                        ctx.fillStyle = grd;
                        //ctx.fillStyle = "#99FFFF";
                        ctx.fill();
                }
        </script>
```

## Draw a line
> Use the lineto function to draw
``` html
        <canvas id="myCanvasline" width="200" height="100" style="border:1px solid #d3d3d3;">
                Your browser does not support the canvas element.
        </canvas>

        <script>
                var canvas = document.getElementById("myCanvasline");
                var ctx = canvas.getContext("2d");
                ctx.moveTo(0, 0);
                ctx.lineTo(200, 100);
                ctx.stroke();
        </script>
```

## Gradient
> Gradients can be used to fill rectangles, circles, lines, text, etc. Shapes on the canvas are not limited to solid colors.

There are two different types of gradients:
- createLinearGradient(x,y,x1,y1) - creates a linear gradient
- createRadialGradient(x,y,r,x1,y1,r1) - creates a radial/circular gradient

Once we have a gradient object, we must add two or more color stops.
The addColorStop() method specifies the color stops, and its position along the gradient. Gradient positions can be anywhere between 0 to 1.

To use the gradient, set the fillStyle or strokeStyle property to the gradient, then draw the shape (rectangle, text, or a line).

### Create gradient
``` html
        <canvas id="myCanvasgra" width="200" height="100" style="border:1px solid #d3d3d3;">
                Your browser does not support the HTML5 canvas tag.</canvas>

        <script>
                var c = document.getElementById("myCanvasgra");
                var ctx = c.getContext("2d");

                // Create gradient
                var grd = ctx.createLinearGradient(0, 0, 200, 0);
                grd.addColorStop(0, "red");
                grd.addColorStop(1, "white");

                // Fill with gradient
                ctx.fillStyle = grd;
                ctx.fillRect(10, 10, 150, 80);
        </script>
```

### Create radial gradient
>
``` html
        <canvas id="myCanvasgr2" width="200" height="100" style="border:1px solid #d3d3d3;">
                Your browser does not support the HTML5 canvas tag.</canvas>

        <script>
                var c = document.getElementById("myCanvasgr2");
                var ctx = c.getContext("2d");

                // Create gradient
                var grd = ctx.createRadialGradient(75, 50, 5, 90, 60, 100);
                grd.addColorStop(0, "red");
                grd.addColorStop(1, "white");

                // Fill with gradient
                ctx.fillStyle = grd;
                ctx.fillRect(10, 10, 150, 80);
        </script>
```

