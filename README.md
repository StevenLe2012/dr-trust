# Dr. Trust - MIT Reality Hacks Winner (Best Use of Bezi)

Connecting doctors and patients by increasing transparency during difficult medical conversations (such as pre-surgery debriefs). Ultimately bolstering patient confidence in the medical system, and allowing healthcare to save more lives.

- Devpost:https://devpost.com/software/dr-trust
- YouTube: https://youtu.be/b7dJazhTQVk?si=TBphu_llmTRP2jBX

[![Dr. Trust](https://i.imgur.com/YiZk0xC.png)](https://youtu.be/b7dJazhTQVk?si=8fTEslpDUvDi1G-E "Dr. Trust")

### Team Contributions: "4 Trojans and a Tree"
- [Steven Le](https://www.linkedin.com/in/stevenle1337/) (Stanford) - Backend Unity with Meta's Presence Platform and Normcore's multiplayer solution.
- [Vikram Agrawal](https://www.linkedin.com/in/vikram-agrawal/) (USC) - Frontend Unity with Bezi Integration
- [Jessica Sheng](https://www.linkedin.com/in/jlsheng/) (USC) - Design with Blender + Bezi
- [Coco Xiong](https://www.linkedin.com/in/ziyuxiong-coco/) (USC) - Design with Bezi and Video Editing + Narrative
- Amanda Leong (USC) - Researcher + Narrative Lead

## Setup

Dr. Trust is a mixed reality experience that can be used both in-person and remotely through a multiplayer internet connection.
Therefore you will need:

### Hardware:

- 2 Meta Quest 3's (or Pro's) - one for the doctor and one for the patient
- Optional: Additional Meta 3/Pro's to bring in a patient's family members (even if they're remote)
- Oculus Touch Controllers (hand tracking will be supported in a future update - controllers offer the required level of precision for now)

### Software Dependencies:

If you're simply using Dr. Trust, you just need to load our APK onto your Quest headset (via Meta Quest Developer Hub or Sideload)

If you'd like to modify our app on your own computer, you'll need these softwares and libraries:

1. Unity
2. Normcore - realtime multi-user sessions
3. OpenXR
4. Unity XR Interaction Toolkit
5. Unity AR Foundation
6. glTFast - rendering glTF and GLB models
   Furthermore, be sure to go to "Project Settings", and switch the target platform to "Android", since Meta Quest is based on Android.

## Launch and Usage

- Launch the app
- Press and hold the Oculus/Meta button to bring the surgical table in front of you
- To interact with an organ, highlight it with the ray, and press the grab (middle finger) button. It will snap to a floating position once released
- To annotate the body outline, cast a ray onto the body, then hit the trigger (index finger) button. It will paint a red line on the body
- To clear all annotations, select the trash bin at the foot of the surgical table with your right controller
- Press 'A' to select your role - "Doctor" or "Patient" and "Physical" or "Remote"; You'll be given corresonding avatars and name tags, and be able to hear others if remote.

### Pushing a modded APK

- Install Meta Quest Development Hub
- Go to "Build Settings" and build an APK
- Drag the .apk file into the Meta Quest Development Hub
- Open your headset and launch

## Shout-Outs

BEZI!!! <3 Bezi made our lives so much easier with such an intuitive way of desigining our work. Before learning about them this hackathon, we'd either struggle with conceptualizing 3D in Figma, painstakingly use a 3D engine like Unity for Spatial Design, or just give up and sketch on paper. Bezi made our 2 designers feel like 5 or 6, despite this being their first time using it. Thank you Julian and Daniel for the great workshop and consistent support!

Sebastian Yang, thank you so much for your amazing dedication to our cause. How we started off with disecting bodies on a beach, to now increasing trust and transparency with surgery.

Steve Lukas, you're the one that lights the path for the younger generation. We love your humor, humbleness, and motivation to seamlessly integrate XR into a specific purpose of life.

Working on Dr. Trust has been such an incredible and purposeful joy.
So the biggest thank you goes to MIT Reality Hacks and all the amazing, hard working event coordinators who made this all possible! An event of this scale can't be easy, and we're so grateful to you for making it happen <3
