var skills;

function getSkills() {
    $.get('/api/skills/getfilteredlist', function(data) {
        $.each(data, function() {
            $("#skillslist").append('<option class="dropdown-item">' + this.name + '</option>');
            switch (this.type) {
            case "ChartSkill":
                $("#chartskilllist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Granted Chart":
                $("#grantedchartlist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "HiddenPrereq":
                $("#hiddenprereqlist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Logistics Entry":
                $("#logisticsentrylist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Purchased Chart":
                $("#purchasedchartslist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Race":
                $("#raceslist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            default:
            }

        });
        $("#skillslist").selectmenu();
        $("#chartskilllist").selectmenu();
        $("#grantedchartlist").selectmenu();
        $("#hiddenprereqlist").selectmenu();
        $("#logisticsentrylist").selectmenu();
        $("#purchasedchartslist").selectmenu();

        $("#raceslist").selectmenu();
        skills = data;
    });
}

function getSkill(skillKey) {
    for (var i = 0; i < skills.length; i++) {
        if (skills[i].skillKey === skillKey) {
            return skills[i];
        }
    }
    return null;
}
