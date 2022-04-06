const uri = 'https://localhost:44388/api/Students/';
let todos = [];

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';
  
    _displayCount(data.length);
  
    const button = document.createElement('button');
  
    data.forEach(item => {
      let isCompleteCheckbox = document.createElement('input');
      isCompleteCheckbox.type = 'checkbox';
      isCompleteCheckbox.disabled = true;
      isCompleteCheckbox.checked = item.isComplete;
  
      let editButton = button.cloneNode(false);
      editButton.innerText = 'Edit';
      editButton.setAttribute('onclick', `displayEditForm(${item.id})`);
  
      let deleteButton = button.cloneNode(false);
      deleteButton.innerText = 'Delete';
      deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);
  
      let tr = tBody.insertRow();
      
      let td1 = tr.insertCell(0);
      td1.appendChild(isCompleteCheckbox);
  
      let td2 = tr.insertCell(1);
      let textNode = document.createTextNode(item.name);
      td2.appendChild(textNode);


  
      let td3 = tr.insertCell(2);
      td3.appendChild(editButton);
  
      let td4 = tr.insertCell(3);
      td4.appendChild(deleteButton);
    });
  
    todos = data;
  }