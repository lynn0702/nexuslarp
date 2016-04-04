var skills= [];
var purchasedCharts = [];
var grantedCharts = [];
var chartSkills = [];

function getSkills() {
    $.get('/api/skills/getfilteredlist', function(data) {
        $.each(data, function() {
            $("#skillslist").append('<option class="dropdown-item">' + this.name + '</option>');
            switch (this.type) {
            case "ChartSkill":
                $("#chartskilllist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                chartSkills.push(this);
                break;
            case "Granted Chart":
                $("#grantedchartlist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                grantedCharts.push(this);
                break;
            case "HiddenPrereq":
                $("#hiddenprereqlist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Logistics Entry":
                $("#logisticsentrylist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            case "Purchased Chart":
                $("#purchasedchartslist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                purchasedCharts.push(this);
                break;
            case "Race":
                $("#raceslist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                break;
            default:
            }

        });

        skills = data;
        buildSkillTree();
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


function buildSkillTree() {
    buildCharts();
    addSkillsToCharts();
    $("#accordionSkillTree").accordion({ heightStyle: "content" });
    $('#accordionSkillTree').on('show hide', function () {
            $(this).css('height', 'auto');
            });
}

function addSkillsToCharts() {
    for (var j = 0; j < skills.length; j++) {
        if (skills[j].type === "ChartSkill") {
            var skillDiv = document.getElementById(skills[j].name + skills[j].chart);
            if (skillDiv) {
                $(skillDiv).append('<li><input type="checkbox" value="None" class="chartSkillCheckBox" id="' +skills[j].skillKey + '" name="check" /></li>');
                var elems = $(skillDiv).children('li').remove();
                elems.sort(function(a, b) {
                    return getSkill(a.firstChild.id).rank < getSkill(b.firstChild.id).rank;
                });
                $(skillDiv).append(elems);
            } else {
                $(document.getElementById(skills[j].chart+'body')).append('<div class="checkbox-grid" id ="' + skills[j].name + skills[j].chart + '" />' + skills[j].name + '</div>');
                $(document.getElementById(skills[j].name +skills[j].chart)).append('<li><input type="checkbox" value="None" class="chartSkillCheckBox" id="' +skills[j].skillKey + '" name="check" /></li>');
            }
        }
    }
};

function buildCharts() {
    var skillTree = $("#accordionSkillTree");
    for (var i = 0; i < grantedCharts.length; i++) {
        skillTree.append(
                    '<h4>'+
                         grantedCharts[i].name +
                    '</h4>' +
                    '<div id="' + grantedCharts[i].skillKey + '">' +
                        '<div id="' + grantedCharts[i].skillKey + 'body">' +
                        '</div>' +
                    '</div>');

    }
    for (var j = 0; j < purchasedCharts.length; j++) {
            skillTree.append(
                     '<h4>' +
                            purchasedCharts[j].name + ' ' + purchasedCharts[j].rank +
                     '</h4>' +
                     '<div id="' + purchasedCharts[j].skillKey + '">' +
                        '<div id="' + purchasedCharts[j].skillKey + 'body">'+
                        '</div>' +
                    '</div>');
    }
   // $("#accordionSkillTree").accordion();
}

function difference(a1, a2) {
  var result = [];
  for (var i = 0; i < a1.length; i++) {
    if (a2.indexOf(a1[i]) === -1) {
      result.push(a1[i]);
    }
  }
  return result;
}