import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Home/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){
    const [infos, setInfos] = useState(props.location.state);
    const [estado, setEstado] = useState('');
    const [cidade, setCidade] = useState('');
    const [genero, setGenero] = useState('');
    const [condicao, setCondicao] = useState('');
    const [barraPesquisa, setBarraPesquisa] = useState('');
    const [anuncios, setAnuncios] = useState([]);

    const consultarAnuncios = async () => {
        try{
            let e = "";
            let ci = "";
            let cond = "";
            let barra = "";
            let g = "";
            if(barraPesquisa == "") {barra = "BarraPesquisa"} else {barra = barraPesquisa};
            if(estado == "") {e = "Estado"} else {e = estado};
            if(cidade == "") {ci = "Cidade"} else {ci = cidade};
            if(genero == "") {g = "Genero"} else {g = genero};
            if(condicao == "") {cond = "Condicao"} else {cond = condicao};
            const resp = await api.consultarAnuncios(barra,e,ci,g,cond);
            setAnuncios(resp);
            console.log(anuncios) 
        }
        catch (e) {
        }
    }

    useEffect(() => {
        consultarAnuncios();
      }, [])

    return(
        <div className="matheus">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 
                <div className="barraPesquisa">
                    <input className="koko2 form-control" type="text" placeholder="Pesquisa" value={barraPesquisa} onChange={(e) => setBarraPesquisa(e.target.value)}></input>
                    <button className="botao1" onClick={consultarAnuncios}>Consultar</button>
                </div>
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos}}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>


            <div className="pedroga">
               
                <div className="pedrin">

                    <div className="pedrox">
                        <label className="matiolas">Estado:</label>
                        <select className="keliki1 form-control" onChange={(e) => setEstado(e.target.value)}>
                            <option value="">Estado</option>
                            <option value="AC">Acre</option>
                            <option value="AL">Alagoas</option>
                            <option value="AP">Amapá</option>
                            <option value="AM">Amazonas</option>
                            <option value="BA">Bahia</option>
                            <option value="CE">Ceará</option>
                            <option value="DF">Distrito Federal</option>
                            <option value="ES">Espírito Santo</option>
                            <option value="GO">Goiás</option>
                            <option value="MA">Maranhão</option>
                            <option value="MT">Mato Grosso</option>
                            <option value="MS">Mato Grosso do Sul</option>
                            <option value="MG">Minas Gerais</option>
                            <option value="PA">Pará</option>
                            <option value="PB">Paraíba</option>
                            <option value="PR">Paraná</option>
                            <option value="PE">Pernambuco</option>
                            <option value="PI">Piauí</option>
                            <option value="RJ">Rio de Janeiro</option>
                            <option value="RN">Rio Grande do Norte</option>
                            <option value="RS">Rio Grande do Sul</option>
                            <option value="RO">Rondônia</option>
                            <option value="RR">Roraima</option>
                            <option value="SC">Santa Catarina</option>
                            <option value="SP">São Paulo</option>
                            <option value="SE">Sergipe</option>
                            <option value="TO">Tocantins</option>            
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Cidade:</label>
                        <input className="koko1 form-control" type="text" onChange={(e) => setCidade(e.target.value)} placeholder="Cidade"></input>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Gênero:</label>
                        <select className="keliki3 form-control" onChange={(e) => setGenero(e.target.value)}>
                            <option value="">Gênero</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Unisex">Unissex</option>
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Condição:</label>
                        <select className="keliki4 form-control" onChange={(e) => setCondicao(e.target.value)}>
                            <option value="">Condição</option>
                            <option value="Novo">Novo</option>
                            <option value="Usado">Usado</option>
                        </select>
                    </div>
                </div>

                    {anuncios.map(x =>
                        <div className="flow">
                            <div className="quadradin"> 
                                <Link to={{ pathname: "/Anuncio", state: x}}>
                                    <div className="ima">
                                        {console.log(x.imagens[0].textoImagem)}
                                        <img src={api.consultarImagem(x.imagens[0])} width="200px" height="200px"></img>
                                    </div>
                                </Link>

                                <div className="alin">
                                    <h5>
                                        <Link to={{ pathname: "/Anuncio", state: {x,infos}}}>
                                            Titulo:&nbsp;{x.titulo}
                                        </Link>
                                    </h5>
                                    <h6>Preço:&nbsp;{x.preco}</h6>
                                    <h6>Marca:&nbsp;{x.marca}</h6>
                                    <h6>Tamanho:&nbsp;{x.tamanho}</h6>
                                    <h6>Condição:&nbsp;{x.condicao}</h6>
                                    <h6>Genero:&nbsp;{x.genero}</h6>
                                </div>
                            </div> 
                        </div>
                    )}

            </div>
            
            
        </div>
    )
}