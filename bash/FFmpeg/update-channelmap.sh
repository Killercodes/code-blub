#!/bin/bash

IN=$1
OP=$2
OUT=$3

if [ "$IN" = "-h" ] || [ "$IN" = "-help" ] || [ "$IN" = "/?" ] 
then
  echo "AV Channel Map convertor"
  echo "program <inputfile> <option> <outputfile>"
  cat << END
  Support mapping: 
    mono FC
    stereo FL+FR
    2.1 FL+FR+LFE
    3.0 FL+FR+FC
    3.0(back) FL+FR+BC
    4.0 FL+FR+FC+BC
    quad FL+FR+BL+BR
    quad(side) FL+FR+SL+SR
    3.1 FL+FR+FC+LFE
    5.0 FL+FR+FC+BL+BR
    5.0(side) FL+FR+FC+SL+SR
    4.1 FL+FR+FC+LFE+BC
    5.1 FL+FR+FC+LFE+BL+BR
    5.1(side) FL+FR+FC+LFE+SL+SR
    6.0 FL+FR+FC+BC+SL+SR
    6.0(front) FL+FR+FLC+FRC+SL+SR
    hexagonal FL+FR+FC+BL+BR+BC
    6.1 FL+FR+FC+LFE+BC+SL+SR
    6.1(back) FL+FR+FC+LFE+BL+BR+BC
    6.1(front) FL+FR+LFE+FLC+FRC+SL+SR
    7.0 FL+FR+FC+BL+BR+SL+SR
    7.0(front) FL+FR+FC+FLC+FRC+SL+SR
    7.1 FL+FR+FC+LFE+BL+BR+SL+SR
    7.1(wide) FL+FR+FC+LFE+BL+BR+FLC+FRC
    7.1(wide-side) FL+FR+FC+LFE+FLC+FRC+SL+SR
    octagonal FL+FR+FC+BL+BR+BC+SL+SR
    hexadecagonal FL+FR+FC+BL+BR+BC+SL+SR+TFL+TFC+TFR+TBL+TBC+TBR+WL +WR
    downmix DL+DR
  END
fi

ffmpeg -i "${IN}" -af "channelmap=channel_layout=${OP}" "${OUT}"
