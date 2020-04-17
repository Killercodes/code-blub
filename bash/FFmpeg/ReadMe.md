# FFmpeg Examples

## Cut video file into a smaller clip 
You can use the time offset parameter (-ss) to specify the start time stamp in HH:MM:SS.ms format while the -t parameter is for specifying the actual duration of the clip in seconds.
``` bash
ffmpeg -i input.mp4 -ss 00:00:50.0 -codec copy -t 20 output.mp4
```

## Split a video into multiple parts
If you want to split a large video into multiple smaller clips without re-encoding, ffmpeg can help. This command will split the source video into 2 parts – one ending at 50s from the start and the other beginning at 50s and ending at the end of the input video.
``` bash
ffmpeg -i video.mp4 -t 00:00:50 -c copy small-1.mp4 -ss 00:00:50 -codec copy small-2.mp4
```

## Convert video from one format to another
You can use the -vcodec parameter to specify the encoding format to be used for the output video. Encoding a video takes time but you can speed up the process by forcing a preset though it would degrade the quality of the output video.
``` bash
ffmpeg -i youtube.flv -c:v libx264 filename.mp4

ffmpeg -i video.wmv -c:v libx264 -preset ultrafast video.mp4
```

## Join (concatenate) video files
If you have multiple audio or video files encoded with the same codecs, you can join them into a single file using FFmpeg. Create a input file with a list of all source files that you wish to concatenate and then run this command.
``` bash
ffmpeg -f concat -i file-list.txt -c copy output.mp4
```

## Mute a video (Remove the audio component)
Use the -an parameter to disable the audio portion of a video stream.
``` bash
ffmpeg -i video.mp4 -an mute-video.mp4
```

## Extract the audio from video
The -vn switch extracts the audio portion from a video and we are using the -ab switch to save the audio as a 256kbps MP3 audio file.
``` bash
ffmpeg -i video.mp4 -vn -ab 256 audio.mp3
```

## Convert a video into animated GIF
FFmpeg is an excellent tool for converting videos into animated GIFs and the quality isn’t bad either. Use the scale filter to specify the width of the GIF, the -t parameter specific the duration while -r specifies the frame rate (fps).
``` bash
ffmpeg -i video.mp4 -vf scale=500:-1 -t 10 -r 10 image.gif
```

## Extract image frames from a video
This command will extract the video frame at the 15s mark and saves it as a 800px wide JPEG image. You can also use the -s switch (like -s 400×300) to specify the exact dimensions of the image file though it will probably create a stretched image if the image size doesn’t follow the aspect ratio of the original video file.
``` bash
ffmpeg -ss 00:00:15 -i video.mp4 -vf scale=800:-1 -vframes 1 image.jpg
```
OR
``` bash
ffmpeg -i foo.avi -r 1 -s WxH -f image2 foo-%3d.jpeg
```
This will extract one video frame per second from the video and will output them in files named foo-001.jpeg, foo-002.jpeg. Images will be rescaled to fit the new WxH values

## Convert Video into Images
You can use FFmpeg to automatically extract image frames from a video every ‘n’ seconds and the images are saved in a sequence. This command saves image frame after every 4 seconds.
``` bash
ffmpeg -i movie.mp4 -r 0.25 frames_%04d.png
```

## Merge an audio and video file
You can also specify the -shortest switch to finish the encoding when the shortest clip ends.
``` bash
ffmpeg -i video.mp4 -i audio.mp3 -c:v copy -c:a aac -strict experimental output.mp4

ffmpeg -i video.mp4 -i audio.mp3 -c:v copy -c:a aac -strict experimental -shortest output.mp4
```
## Resize a video
Use the size (-s) switch with ffmpeg to resize a video while maintaining the aspect ratio.
``` bash
ffmpeg -i input.mp4 -s 480x320 -c:a copy output.mp4
```

## Create video slideshow from images
This command creates a video slideshow using a series of images that are named as img001.png, img002.png, etc. Each image will have a duration of 5 seconds (-r 1/5).
``` bash
ffmpeg -r 1/5 -i img%03d.png -c:v libx264 -r 30 -pix_fmt yuv420p slideshow.mp4
```

## Add a poster image to audio
You can add a cover image to an audio file and the length of the output video will be the same as that of the input audio stream. This may come handy for uploading MP3s to YouTube.
``` bash
ffmpeg -loop 1 -i image.jpg -i audio.mp3 -c:v libx264 -c:a aac -strict experimental -b:a 192k -shortest output.mp4
```

## Convert a single image into a video
Use the -t parameter to specify the duration of the video.
``` bash
ffmpeg -loop 1 -i image.png -c:v libx264 -t 30 -pix_fmt yuv420p video.mp4
```

## Add subtitles to a movie
This will take the subtitles from the .srt file. FFmpeg can decode most common subtitle formats.
``` bash
ffmpeg -i movie.mp4 -i subtitles.srt -map 0 -map 1 -c copy -c:v libx264 -crf 23 -preset veryfast output.mkv
```

## Crop an audio file
This will create a 30 second audio file starting at 90 seconds from the original audio file without transcoding.
``` bash
ffmpeg -ss 00:01:30 -t 30 -acodec copy -i inputfile.mp3 outputfile.mp3
```

## Change the audio volume
You can use the volume filter to alter the volume of a media file using FFmpeg. This command will half the volume of the audio file.
``` bash
ffmpeg -i input.wav -af 'volume=0.5' output.wav
```

## Rotate a video
This command will rotate a video clip 90° clockwise. You can set transpose to 2 to rotate the video 90° anti-clockwise.
``` bash
ffmpeg -i input.mp4 -filter:v 'transpose=1' rotated-video.mp4
```
This will rotate the video 180° counter-clockwise.
``` bash
ffmpeg -i input.mp4 -filter:v 'transpose=2,transpose=2' rotated-video.mp4
```

## Speed up or Slow down the video
You can change the speed of your video using the setpts (set presentation time stamp) filter of FFmpeg. This command will make the video 8x (1/8) faster or use setpts=4*PTS to make the video 4x slower.
``` bash
ffmpeg -i input.mp4 -filter:v "setpts=0.125*PTS" output.mp4
```

## Speed up or Slow down the audio
For changing the speed of audio, use the atempo audio filter. This command will double the speed of audio. You can use any value between 0.5 and 2.0 for audio.
``` bash
ffmpeg -i input.mkv -filter:a "atempo=2.0" -vn output.mkv
```
## channelsplit
Split each channel from an input audio stream into a separate output stream.

It accepts the following parameters:

**channel_layout**
The channel layout of the input stream. The default is "stereo".

**channels**
A channel layout describing the channels to be extracted as separate output streams or "all" to extract each input channel as a separate stream. The default is "all".

Choosing channels not present in channel layout in the input will result in an error.


For example, assuming a stereo input MP3 file,
```
ffmpeg -i in.mp3 -filter_complex channelsplit out.mkv
```
will create an output Matroska file with two audio streams, one containing only the left channel and the other the right channel.

Split a 5.1 WAV file into per-channel files:
```
ffmpeg -i in.wav -filter_complex
'channelsplit=channel_layout=5.1[FL][FR][FC][LFE][SL][SR]'
-map '[FL]' front_left.wav -map '[FR]' front_right.wav -map '[FC]'
front_center.wav -map '[LFE]' lfe.wav -map '[SL]' side_left.wav -map '[SR]'
side_right.wav
```
Extract only LFE from a 5.1 WAV file:
```
ffmpeg -i in.wav -filter_complex 'channelsplit=channel_layout=5.1:channels=LFE[LFE]'
-map '[LFE]' lfe.wav
```

## channelmap
Remap input channels to new locations.

It accepts the following parameters:

For example, assuming a 5.1+downmix input MOV file,
```
ffmpeg -i in.mov -filter 'channelmap=map=DL-FL|DR-FR' out.wav
```
will create an output WAV file tagged as stereo from the downmix channels of the input.

To fix a 5.1 WAV improperly encoded in AAC’s native channel order
```
ffmpeg -i in.wav -filter 'channelmap=1|2|0|5|3|4:5.1' out.wav
```

## aresample

Resample the input audio to the specified parameters, using the libswresample library. If none are specified then the filter will automatically convert between its input and output.

This filter is also able to stretch/squeeze the audio data to make it match the timestamps or to inject silence / cut out audio to make it match the timestamps, do a combination of both or do neither.

The filter accepts the syntax [sample_rate:]resampler_options, where sample_rate expresses a sample rate and resampler_options is a list of key=value pairs, separated by ":".

Resample the input audio to 44100Hz:
```
aresample=44100
```
Stretch/squeeze samples to the given timestamps, with a maximum of 1000 samples per second compensation:
```
aresample=async=1000
```
