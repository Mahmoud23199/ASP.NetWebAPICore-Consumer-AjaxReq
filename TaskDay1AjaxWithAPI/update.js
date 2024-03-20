var btnInsert = document.getElementById("btnInsert");
var inserName = document.getElementById("InserName");
var insertDec = document.getElementById("InsertDec");

var toastElement = document.querySelector(".toast");



btnInsert.addEventListener("click", function () {
  var name = inserName.value;
  var dec = insertDec.value;

  if (isFinite(name) || name == "") {
    setTimeout(() => {
      var toast = new bootstrap.Toast(toastElement);
      toast.show();
    }, 100);
  } else {
    addCourse(name, dec);
  }

  console.log(name, dec);
});

async function addCourse(name, desc) {
    try {
      var response = await fetch(`http://localhost:40307/api/Course`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ name: name, description: desc }), 
      });
      if (!response.ok) {
        throw new Error(`Failed to add course: ${response.statusText}`);
      } else {
        console.log("Course added successfully.");
        toastElement.textContent = "Course added successfully."; // Corrected variable name
        toastElement.style.backgroundColor = "green"; // Corrected variable name
        inserName.value="";
        insertDec.value="";
        setTimeout(() => {
          var toast = new bootstrap.Toast(toastElement);
          toast.show();
        }, 100);
      }
    } catch (error) {
      console.error("An error occurred:", error);
    }
  }
  

  //-------------------------------------------------------------update 

var btnUpdate = document.getElementById("btnUpdate");
var updateId= document.getElementById("updateId");
var updateName = document.getElementById("updateName");
var updateDec = document.getElementById("updateDesc");

var toastElement = document.querySelector(".toast");



btnUpdate.addEventListener("click", function () {
  var idUp =Number(updateId.value);
  var name = updateName.value;
  var dec = updateDec.value;

  if(idUp==""||name==""||!isFinite(idUp)||isFinite(name)||dec=="")
  {
    setTimeout(() => {
        var toast = new bootstrap.Toast(toastElement);
        toast.show();
      }, 100);
  }
  else
  {
    updateCourse(idUp,name,dec);

  }


 
});

async function updateCourse(i, n, dec) {
    try {
        const response = await fetch(`http://localhost:40307/api/Course/${i}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: i, name: n, description: dec }),
        });

        if (!response.ok) {
            throw new Error(`Failed to update course: ${response.statusText}`);
        }

        console.log('Course updated successfully.');

        const toastElement = document.querySelector('.toast');
        toastElement.textContent = 'Course updated successfully.';
        toastElement.style.backgroundColor = 'green';

        document.getElementById('updateId').value = '';
        document.getElementById('updateName').value = '';
        document.getElementById('updateDesc').value = '';

        setTimeout(() => {
            const toast = new bootstrap.Toast(toastElement);
            toast.show();
        }, 100);
    } catch (error) {
        console.error('An error occurred:', error);
    }
}

