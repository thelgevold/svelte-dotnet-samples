<h1>{ greeting }</h1>

{#each friends as friend}
		<div><span>{ friend.FirstName }</span> <span>{ friend.LastName }</span></div>
{/each}

<script>
import { onMount } from 'svelte';

const greeting = "Hello from Svelte and .Net";

let allFriends = [];
let friends = [];

onMount(async () => {
  const response = await Get('application/x-msgpack');
  
  for await (const friend of MessagePack.decodeArrayStream(response.body)) {
    allFriends = [friend, ...friends];
    friends = allFriends.slice(0, 20);
  }
})

function Get(contentType) {
  return fetch('/friends', {
    headers: {
      'Content-Type': contentType,
      'Accept': contentType,
      'Transfer-Encoding': 'chunked'
    }
  });
}

</script>