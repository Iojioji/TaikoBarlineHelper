A program to make some of osu!taiko mapping gimmicks easier to iterate on

- - - -

### What it does
- It can make Barlines yes

### How to use
1. Make sure your hitobjects directly land on green lines in osu!editor <sup>1</sup>
2. Copy the (green) lines you want to barline <sup>2</sup>
3. Paste those lines in the text field
4. Select which notes you want to make barlines on by checking the boxes
5. Configure what you want to do with each one of those
   - Barline Amount is how many barlines will be created in front and behind the note (1 will make 1 barline -1ms and another barline +1ms from a given circle)
   - Barline Spacing is how many ms apart the barlines will be after the first barline. If Barline Amount is 1, this setting will do nothing. If barline amount is 2, a there will be barlines at -3, -1, 1 and 3 ms from a given circle. (default for first lines is ±1, the 2 will add to this)
   - SV Change makes barlines with an Amount of more than 1 to have increasing SV changes, so they kinda fan into place
7. Click "Barline It!"
8. Press "Oops" button to undo the changes
9. Check "Is Tutorial" if you want notes to still be visible on top of the barlines.

<sup>1</sup> <sub>The barlines will only be applied if the notes land directly on the green lines.</sub>  
<sup>2</sup> <sub>These steps work like this for the time being, I'm already working on making them work more intuitively (~~but I only work on this when I'm actively using it to map something oops~~)</sub>

- - - -

### TODOS
- [ ] Refactor how it does the things to make it easier to implement multiple gimmicks on one go
- [ ] Support more gimmicks
  - [ ] Inverse Barlines
  - [ ] Yellow Notes
